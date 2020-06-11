using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportSystem.Interfaces;
using System.Net.Mail;

namespace ReportSystem.Services
{
    public class EmailService:IEmailService
    {
        public void SendEmail(string To, string Subject, string BodyContent)
        {
            MailMessage mm = new MailMessage();
            mm.To.Add(To);
            mm.Subject = Subject;
            mm.Body = BodyContent;
            mm.From = new MailAddress("nemesys.sergiu@gmail.com");
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("nemesys.sergiu@gmail.com", "ADmin1234");
            smtp.Send(mm);
            
        }
    }
}
