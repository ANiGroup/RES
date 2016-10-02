using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affinity.Helper.Services
{
    /// <summary>
    /// Send mail message
    /// </summary>
    public class mailNotificationHelper
    {
        /// <summary>
        /// The smtp Client 
        /// </summary>
        private System.Net.Mail.SmtpClient _mClient { get; set; }
        /// <summary>
        /// Variable with From mail 
        /// </summary>
        private string mFrom { get; set; }

        /// <summary>
        /// initialize the smtp server.
        /// </summary>
        /// <param name="mHost">The Host</param>
        /// <param name="mmail">The From mail</param>
        /// <param name="muser">The mail user(SendGrid or any other)</param>
        /// <param name="mpass">The mail Password</param>
        /// <param name="smtpPort">The port</param>
        /// <param name="useSSL">use SSL</param>
         public mailNotificationHelper(string mHost,string mmail ,string muser, string mpass,int smtpPort ,Boolean useSSL)
        {
            _mClient = new System.Net.Mail.SmtpClient(mHost);
            _mClient.Credentials = new System.Net.NetworkCredential(muser, mpass);
            _mClient.Port = smtpPort;
            _mClient.EnableSsl = useSSL;
            mFrom = mmail;
        }

        /// <summary>
        /// Send the mail message
        /// </summary>
        /// <param name="To">To Address</param>
        /// <param name="subject">Subject</param>
        /// <param name="msgBody">Body</param>
        public void mSend(string[] To,string subject,string msgBody)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From =new System.Net.Mail.MailAddress(mFrom);
            msg.To.Add(new System.Net.Mail.MailAddress(mFrom));
            for (int i = 0; i < To.Length; i++)
            {
                msg.Bcc.Add(new System.Net.Mail.MailAddress(To[i]));
            }
           
            msg.Subject = subject;
            msg.Body = msgBody;
            msg.IsBodyHtml = true;
            _mClient.Send(msg);
        }
    }
}
