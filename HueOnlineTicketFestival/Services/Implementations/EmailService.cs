using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HueOnlineTicketFestival.data;
using HueOnlineTicketFestival.Services.Interfaces;
using MimeKit;

namespace HueOnlineTicketFestival.Services.Implementations
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(EmailDTO request, string filepath = null!)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("hank.swift@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;

            if (filepath != null)
            {
                var image = new MimePart("image", "jpeg")
                {
                    Content = new MimeContent(File.OpenRead(filepath)),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = Path.GetFileName(filepath)
                };
                var multipart = new Multipart("mixed");
                multipart.Add(image);
                multipart.Add(new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = request.Body,
                });
                email.Body = multipart;
            }
            else
            {
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = request.Body,

                };
            }
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            await smtp.ConnectAsync("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("hank.swift@ethereal.email", "P7yTz38cQKNbhSddR9");
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}