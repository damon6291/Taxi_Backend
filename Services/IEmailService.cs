namespace WMS_backend.Services
{
    public interface IEmailService
    {
        public void SendWelcomeEmail(string clientEmail, string token);
        public void SendResetPasswordEmail(string clientEmail, string token);
    }
}
