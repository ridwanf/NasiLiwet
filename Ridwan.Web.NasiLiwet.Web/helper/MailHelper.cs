using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Ridwan.Web.NasiLiwet.Web.helper
{
    public static class MailHelper
    {
        private static readonly string To = ConfigurationManager.AppSettings["To"];
        private static readonly string User = ConfigurationManager.AppSettings["User"];
        private static readonly string Pass = ConfigurationManager.AppSettings["Pass"];

        public static bool SendEmail(string from, string subject, ListDictionary param, string bodyTemplate)
        {
            var subjectEmail = "Email From " + subject + '-' + from;
            var result= SendEmail(from, subjectEmail, param, bodyTemplate, null);
            return result;
        }

        public static bool SendEmail(string from, string subject, ListDictionary param, string bodyTemplate,
              FileContentResult urlAttachment)
        {
            try
            {
                var client = new SmtpClient();
                client.UseDefaultCredentials = true;
                client.Host = "smtp.gmail.com";
                client.Credentials = new NetworkCredential(User,Pass);
                client.Port = 587;
                client.EnableSsl = true;
                var mail = ComposeMail(To, from,subject, param, bodyTemplate, urlAttachment);
                AlternateView view = AlternateView.CreateAlternateViewFromString(bodyTemplate, null,
                                                           MediaTypeNames.Text.Html);
                mail.AlternateViews.Add(view);
                mail.IsBodyHtml = true;

                client.Send(mail);

                client.Dispose();
                mail.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static MailMessage ComposeMail(string to,string from, string subject, ListDictionary param, string bodyTemplate, FileContentResult urlAttachment)
        {
            var mailDefinition = new MailDefinition
            {
                From = from,
                Subject = subject,
                IsBodyHtml = true,
                

            };

            var mail = mailDefinition.CreateMailMessage(to, param, bodyTemplate, new System.Web.UI.Control());

            if (urlAttachment == null)
                return mail;

            // Create an in-memory System.IO.Stream
            var ms = new MemoryStream(urlAttachment.FileContents);
            var ct = new ContentType(urlAttachment.ContentType);
            var a = new Attachment(ms, ct);
            mail.Attachments.Add(a);

            return mail;
        }
    }
}