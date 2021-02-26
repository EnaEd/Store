using MailKit.Net.Smtp;
using MimeKit;
using Store.Shared.Providers.Interfaces;
using System.Threading.Tasks;

namespace Store.Shared.Providers
{
    public class EmailProvider : IEmailProvider
    {
        public EmailProvider()
        {
        }
        public async Task SendEmailAsync(string mail, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(
                "Site administration",
                "devacccom@outlook.com"));
            emailMessage.To.Add(new MailboxAddress(string.Empty, mail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp-mail.outlook.com", 587, false);

                await client.AuthenticateAsync("devacccom@outlook.com", "1234567890test");

                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
