using WMS_backend.Models.Permission;

namespace WMS_backend.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Get the user ID from http context
        /// </summary>
        /// <returns></returns>
        public Guid? GetUserId();
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        /// <summary>
        /// Create JWT Token Expiring in 12 hour
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string CreateToken(Guid userId);
        /// <summary>
        /// Create JWT Token Expiring in 10 minutes
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string CreateTemporaryToken(Guid userId); 
    }
}
