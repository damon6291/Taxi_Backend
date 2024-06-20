using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Text;

namespace WMS_backend.Services
{
    public class EmailService : IEmailService
    {
        private string emailReceiver;
        private string emailHost;
        private string emailUserName;
        private string emailPassword;
        private int emailPort;
        private string apiurl;

        public EmailService(IConfiguration configuration)
        {
            emailReceiver = configuration.GetValue<string>("Email:EmailReceiver")!;
            emailHost = configuration.GetValue<string>("Email:EmailHost")!;
            emailUserName = configuration.GetValue<string>("Email:EmailUserName")!;
            emailPassword = configuration.GetValue<string>("Email:EmailPassword")!;
            emailPort = configuration.GetValue<int?>("Email:EmailPort") ?? 587;
            apiurl = configuration.GetValue<string>("Others:apiurl")!;
        }
        public void SendResetPasswordEmail(string clientEmail, string token)
        {
            throw new NotImplementedException();
        }

        public void SendWelcomeEmail(string clientEmail, string token)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailUserName));
            email.To.Add(MailboxAddress.Parse(clientEmail));
            email.Subject = "Welcome to WMS";
            var url = $"{apiurl}/api/Auth/Welcome?token={token}";
            email.Body = new TextPart(TextFormat.Html) { Text = $"<div>Welcome, please click the link to set your password. <a href=\"{url}\">Set Password</a><div>" };
            //var bodyBuilder = new BodyBuilder();
            //bodyBuilder.HtmlBody = CreateAuthBody(url);
            //bodyBuilder.TextBody = "-"; // Place holder
            //bodyBuilder.TextBody = "Email Confirmation";
            //email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(emailHost, emailPort, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailUserName, emailPassword);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
