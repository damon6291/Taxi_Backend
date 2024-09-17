using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using WMS_backend.Models.Permission;
using Microsoft.AspNetCore.Identity;
using WMS_backend.Models.DBModels;

namespace WMS_backend.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> userManager;
        private string secretKey;

        public UserService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            secretKey = configuration.GetValue<string>("AppSettings:Token")!;
        }

        public async Task<AppUser?> GetUser()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                var temp =  await userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
                return temp;
            }
            return null;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public string CreateToken(Guid userId)
        {
            return CreateToken(userId, DateTime.UtcNow.AddMinutes(30));
        }

        public string CreateTemporaryToken(Guid userId)
        {
            return CreateToken(userId, DateTime.UtcNow.AddMinutes(10));
        }

        private string CreateToken(Guid userId, DateTime expires)
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.UserData, userId.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
