using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WebMonitorService.Objects
{
    public static class Common
    {
        private const string htmlBreak = "</br>";
        private static void SendEmail(string subject, string body)
        {
            List<string> emailTo = Config.EmailAddresses;            
            MailMessage message = new MailMessage();

            foreach (string address in emailTo)
            {
                message.To.Add(new MailAddress(address));
            }

            message.From = new MailAddress(Config.EmailFromAddress);
            message.Subject = subject;            
            message.IsBodyHtml = true;
            message.Body = body;

            using (SmtpClient client = new SmtpClient())
            {
                client.Host = Config.EmailServer;
                client.Send(message);
            }            
        }

        public static void SendErrorEmail(Exception ex)
        {
            SendErrorEmail(ex, null);
        }

        public static void SendErrorEmail(Exception ex, string url)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Config.ErrorEmailSubject + htmlBreak);

            if (!string.IsNullOrEmpty(url))
            {
                sb.Append("Application: " + url + htmlBreak);
            }           

            sb.Append(ex.Message + htmlBreak);
            sb.Append(ex.StackTrace);
            Common.SendEmail(Config.ErrorEmailSubject, sb.ToString());
        }

        public static void SendErrorSummaryReport(List<WebApplicationTest> appList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Config.SummaryEmailSubject + htmlBreak);
            foreach (WebApplicationTest app in appList)
            {
                sb.Append(app.Url + " Response Code:" + app.ResponseCode + htmlBreak);                

                if (app.ResponseHeaders != null)
                {
                    sb.Append(htmlBreak + "Response Headers: " + htmlBreak);
                    int index = 0;
                    foreach (string s in app.ResponseHeaders.Keys)
                    {                        
                        sb.Append(app.ResponseHeaders.Keys[index] + ": " + app.ResponseHeaders[index] + htmlBreak);
                        index++;
                    }
                }

                sb.Append(htmlBreak); 
            }

            Common.SendEmail(Config.SummaryEmailSubject, sb.ToString());
        }

        public static void SendWarningSummaryReport(List<WebApplicationTest> appList)
        {

        }
    }
}
