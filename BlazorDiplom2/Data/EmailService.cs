using MailKit.Net.Smtp;
using MimeKit;

namespace BlazorDiplom2.Data
{
    public class EmailService
    {

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "artyom.zhuravlyov.spbk@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.metanit.com", 465, true);
                await client.AuthenticateAsync("artyom.zhuravlyov.spbk@mail.ru", "Pvt56pzbn");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
