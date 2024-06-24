using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WMS_backend.Data;
using WMS_backend.Mapper;
using WMS_backend.Models.Auth;
using WMS_backend.Models.DBModels;
using WMS_backend.Models.Enums;
using WMS_backend.Models.Permission;
using WMS_backend.Services;

namespace WMS_backend.Managers
{
    public class AuthManager
    {
        private readonly WMSDbContext context;
        private readonly IUserService userService;
        private readonly IEmailService emailService;

        public AuthManager(WMSDbContext context, IUserService userService, IEmailService emailService)
        {
            this.context = context;
            this.userService = userService;
            this.emailService = emailService;
        }

        public async Task<User?> GetUser(Guid userId)
        {
            var ret = await context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            return ret;
        }

        public async Task<User?> GetActiveUserByEmail(string email)
        {
            var ret = await context.User.FirstOrDefaultAsync(x => x.Email == email && !x.IsArchived);
            return ret;
        }

        public async Task<string?> CheckPermission(Guid userId, EnumPermissionType[] permissions, bool isCrud)
        {
            string? ret = null;
            var permissionList = permissions.Select(x => new { PermissionType = x }).ToList();
            var havePermission = await context.UserPermission.Where(x => x.UserId == userId && isCrud ? x.IsCrud : true).WhereBulkContains(permissionList, x => x.PermissionType).CountAsync();
            if (havePermission > 0) return ret;
            ret = ("User does not have permission");
            return ret;
        }

        public async Task<(bool, string)> Login(LoginDTO dto) 
        {
            try
            {
                var user = await GetActiveUserByEmail(dto.Email);
                if (user == null) return (false, "Email does not exist");

                var verify = userService.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt);
                if (!verify) return (false, "Password does not match");

                var token = CreateToken(user.UserId, false);
                user.LastLoginDateTime = DateTime.UtcNow;
                context.SaveChanges();

                return (true, token);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string)> Register(Guid userId, UserDTO dto)
        {
            try
            {
                var user = await GetUser(userId);
                if (user == null) return (false, "User does not exist");

                var newUser = UserMapper.DTOToUser(dto);
                newUser.CompanyId = user.CompanyId;
                newUser.ModifiedUserId = userId;
                context.Add(newUser);
                await context.SaveChangesAsync();

                var token = CreateToken(user.UserId, false);
                emailService.SendWelcomeEmail(newUser.Email, token);

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string)> RegisterAdmin()
        {
            try
            {
                var activeUser = await GetActiveUserByEmail("damon6291@gmail.com");
                if (activeUser != null) return (false, "Already exist");
                var user = new User
                {
                    Email = "damon6291@gmail.com",
                    FirstName = "Damon",
                    LastName = "Joung",
                };
                userService.CreatePasswordHash("1234", out var passwordHash, out var passwordSalt);
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
                context.Add(user);
                await context.SaveChangesAsync();
                await context.PermissionType.InsertFromQueryAsync("userpermission", x => new { userid = user.UserId, permissiontype = x.PermissionTypeId, iscrud = true });
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string)> Refresh(Guid userId)
        {
            try
            {
                var user = await GetUser(userId);
                if (user == null) return (false, "User does not exist");

                var token = CreateToken(user.UserId, false);

                return (true, token);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string)> ResetPassword(Guid userId, string password)
        {
            try
            {
                var user = await GetUser(userId);
                if (user == null) return (false, "User does not exist");

                userService.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
                user.PasswordSalt= passwordSalt;
                user.PasswordHash= passwordHash;
                await context.SaveChangesAsync();

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string)> ForgotPassword(string email)
        {
            try
            {
                var user = await GetActiveUserByEmail(email);
                if (user == null) return (false, "User does not exist");

                var token = CreateToken(user.UserId, true);
                emailService.SendResetPasswordEmail(user.Email,token);

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, object)> GetMe(Guid userId)
        {
            try
            {
                var user = await GetUser(userId);
                if (user == null) return (false, "User does not exist");

                var userDTO = UserMapper.UserToDTO(user);

                return (true, userDTO);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        private string CreateToken(Guid userId, bool isTemporary)
        {
            string? token;
            if (isTemporary)
            {
                token = userService.CreateTemporaryToken(userId);
            }
            else
            {
                token = userService.CreateToken(userId);
            }
            return token;
        }


    }
}
