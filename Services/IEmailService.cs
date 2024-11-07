namespace Taxi_Backend.Services
{
    public interface IEmailService
    {
        public void SendWelcomeEmail(string clientEmail, string token);
        public void SendResetPasswordEmail(string clientEmail, string token);
    }
}
