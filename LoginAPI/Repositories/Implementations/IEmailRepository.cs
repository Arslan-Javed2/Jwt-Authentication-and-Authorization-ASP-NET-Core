using LoginAPI.Data;
using LoginAPI.Repositories.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace LoginAPI.Repositories.Implementations
{
    public class IEmailRepository : IEmail
    {
        private readonly MyDBContext _context;

        public IEmailRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> SendEmail(string body)
        {
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("helena.howell48@ethereal.email"));
            //email.To.Add(MailboxAddress.Parse("helena.howell48@ethereal.email"));
            //email.Subject = "Test Email";
            //email.Body = new TextPart(TextFormat.Html) { Text = body };

            //using (var smtp = new SmtpClient())
            //{
            //    smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            //    smtp.Authenticate("helena.howell48@ethereal.email", "hfaM7JKkywcke3Me5T");
            //    smtp.Send(email);
            //    smtp.Disconnect(true);

            //}
            //return new OkResult() { };


            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("m.arslanjaved2001@gmail.com"));
            email.To.Add(MailboxAddress.Parse("m.arslanjaved2001@gmail.com"));
            email.Subject = "Test Email";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("m.arslanjaved2001@gmail.com", "2018-Ee-144");
                smtp.Send(email);
                smtp.Disconnect(true);

            }
            return new OkResult() { };
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
