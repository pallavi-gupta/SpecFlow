using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using OpenQA.Selenium;

namespace SpecFlowProject1.Utility
{
    class SeleniumEmailReport
    {
        string reportFilePath = "/Users/pallavigupta/Projects/SpecFlowCalculator/SpecFlowProject1/TestResults/SampleHTMLFile.html";

        // Example email configuration
        string smtpServer = "smtp.gmail.com";
        int smtpPort = 587; // Update with your SMTP port number
        private string senderEmail = ExtensionCommonMethod.getpropertyvalue("emailIdFrom");
        string senderPassword = ExtensionCommonMethod.getpropertyvalue("passwordFrom");
        string recipientEmail = ExtensionCommonMethod.getpropertyvalue("emailIdTo");
        string subject = ExtensionCommonMethod.getpropertyvalue("emailSubject");
        string body = "This is a test email.";
        public void Mail()
        {
            if(ExtensionCommonMethod.getpropertyvalue("emailSend").ToLower().Equals("yes"))
            {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient(smtpServer))
                {
                    
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    smtpClient.EnableSsl = true;

                    MailMessage mail = new MailMessage(senderEmail, recipientEmail, subject, body);
                    Attachment attachment = new Attachment(reportFilePath);
                    mail.Attachments.Add(attachment);

                    smtpClient.Send(mail);

                    Console.WriteLine("Email sent successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send email. Error: " + ex.Message);
            }
           
        }
        }
    }
}