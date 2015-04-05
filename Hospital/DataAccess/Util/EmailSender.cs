using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Hospital.DataAccess.Util
{
    public class EmailSender
    {
        public EmailSender()
        { 
        
        }

        public void sendEMailThroughGmail(String emailAddress, String topic, String content)
        {
            try
            {
                //Mail Message
                MailMessage mM = new MailMessage();
                //Mail Address
                mM.From = new MailAddress("hospital.amazing.system@gmail.com");
                //receiver email id
                mM.To.Add(emailAddress);
                //subject of the email
                mM.Subject = topic;
                //deciding for the attachment
                //add the body of the email
                mM.Body = content;
                mM.IsBodyHtml = true;
                //SMTP client
                SmtpClient sC = new SmtpClient("smtp.gmail.com");
                //port number for Gmail mail
                sC.Port = 587;
                //credentials to login in to Gmail account
                sC.Credentials = new NetworkCredential("hospital.amazing.system@gmail.com", "hello12345678");
                //enabled SSL
                sC.EnableSsl = true;
                //Send an email
                sC.Send(mM);
            }//end of try block
            catch (NullReferenceException ex)
            {

            }//end of catch
        }

    }
}
