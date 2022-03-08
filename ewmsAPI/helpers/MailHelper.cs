using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ewms.common.models;

namespace ewms.common.Helpers
{
   public class MailHelper
    {
        //public void SendEmail(string email, string password , string addresses, string subject, string message, string attachment)
        //{
        //    if (!Common.param.send_mail)
        //    {
        //        return;
        //    }            

        //    var loginInfo = new NetworkCredential(email, password);
        //    var msg = new MailMessage();
        //    var smtpClient = new SmtpClient("smtp.gmail.com", 587);            

        //    msg.From = new MailAddress(email);
        //    msg.To.Add(addresses);
        //    msg.Subject = subject;
        //    msg.Body = message;
        //    msg.IsBodyHtml = true;

        //    if (attachment != "")
        //    {
        //        Attachment att = Attachment.CreateAttachmentFromString(attachment.ToString(), "text/html", System.Text.Encoding.UTF8, System.Net.Mime.MediaTypeNames.Text.Html);

        //        att.ContentDisposition.FileName = subject;

        //        msg.Attachments.Add(att);

        //    }

        //    smtpClient.EnableSsl =  true;
            
        //    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    smtpClient.UseDefaultCredentials = false;
        //    smtpClient.Credentials = loginInfo;

            

        //    smtpClient.Timeout = (5 * 60 * 1000);

        //    smtpClient.Send(msg);
            
        //}


        public void SendEmailOlmeca(string addresses, string subject, string message, string attachment)
        {
            try
            {



                var loginInfo = new NetworkCredential("ewms@olmeca.com.gt", "Hame2010");
                var msg = new MailMessage();
                var smtpClient = new SmtpClient("mail.olmeca.com.gt", 25);

                msg.From = new MailAddress("ewms@olmeca.com.gt");
                msg.To.Add(addresses);
                msg.Subject = subject;
                msg.Body = message;
                msg.IsBodyHtml = false;

                if (attachment != "")
                {
                    Attachment att = Attachment.CreateAttachmentFromString(attachment.ToString(), "text/html", System.Text.Encoding.UTF8, System.Net.Mime.MediaTypeNames.Text.Html);

                    att.ContentDisposition.FileName = subject;

                    msg.Attachments.Add(att);

                }

                smtpClient.EnableSsl = false;

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;



                smtpClient.Timeout = (5 * 60 * 1000);

                smtpClient.Send(msg);


            }
            catch (Exception ex)
            {
                //bcgHelper.saveLog(ex.Message, "SendEmailOlmeca");
                
            }


        }


        public void SendEmailOlmecaV2( string addresses, string subject, string message, string attachment)
        {
            try
            {

                string email = "";
                string password = "";

                email = "ewms@agroindustrias.hame";
                password = "Hame2010";
                //email = "ewms@olmeca.com.gt";
                //password = "Hame2010";



                MailMessage oMail = new MailMessage();
                oMail.From = new MailAddress(email);
                oMail.To.Add(addresses);
                oMail.Subject = subject;
                oMail.Body = message;
                oMail.IsBodyHtml = false;

                oMail.Priority = MailPriority.Normal;
                oMail.SubjectEncoding = System.Text.Encoding.UTF8;

                SmtpClient oSMTPServer = new SmtpClient("mail.olmeca.com.gt");
                oSMTPServer.Port = 25;
                oSMTPServer.EnableSsl = false;
                

                //oSMTPServer.Credentials = new System.Net.NetworkCredential(email, password, "agrocentro.com");
                oSMTPServer.Credentials = new System.Net.NetworkCredential(email, password);
                oSMTPServer.EnableSsl = false;


                oSMTPServer.Timeout = (5 * 60 * 1000);



                oSMTPServer.Send(oMail);



            }
            catch (Exception ex)
            {

                //bcgHelper.saveLog(ex.Message, "SendEmailOlmecaV2");

            }

            

            
        }

        public void SendEmailOlmecaV21(string addresses, string subject, string message, string attachment)
        {
            try
            {

                string email = "";
                string password = "";

                email = "ewms@agroindustrias.hame";
                password = "Hame2010";
                //email = "ewms@olmeca.com.gt";
                //password = "Hame2010";



                MailMessage oMail = new MailMessage();
                oMail.From = new MailAddress(email);
                oMail.To.Add(addresses);
                oMail.Subject = subject;
                oMail.Body = message;
                oMail.IsBodyHtml = true;

                oMail.Priority = MailPriority.Normal;
                oMail.SubjectEncoding = System.Text.Encoding.UTF8;

                SmtpClient oSMTPServer = new SmtpClient("mail.olmeca.com.gt");
                oSMTPServer.Port = 25;
                oSMTPServer.EnableSsl = false;


                //oSMTPServer.Credentials = new System.Net.NetworkCredential(email, password, "agrocentro.com");
                oSMTPServer.Credentials = new System.Net.NetworkCredential(email, password);
                oSMTPServer.EnableSsl = false;


                oSMTPServer.Timeout = (5 * 60 * 1000);



                oSMTPServer.Send(oMail);



            }
            catch (Exception ex)
            {

                //bcgHelper.saveLog(ex.Message, "SendEmailOlmecaV2");

            }
        }

    }
}
