using Micro.Business.Abstracts;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
//using WebApi.Helpers;

namespace Micro.Business.Concrates
{
    public class EmailManager : IEmailManager
    {
        public void Send(string to, string subject, string body)
        {            
            string from = "";
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };
                        
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("SmtpUser", "SmtpPass");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
