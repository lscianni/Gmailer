using System;
using System.Net.Mail;

namespace GmailerConsoleApplication
{    
    public class MsgBody
    {
        public string MsgRaw()
        {
            Console.WriteLine("Message (Press enter to send message):");
            string msg = Console.ReadLine();
            
            return msg;
            
        }
    }
    
    class MainClass
    {
        static void Main(string[] args)
        {
            var Msg = new MsgBody();
            
            if (args.Length == 0)
            {
                Console.WriteLine("gmailer \nsend emails using a gmail account");
                Console.WriteLine("Usage: gmailer.exe [emailaddress] [password] [subject] [recipient]");
                
            }
            
            else if (args.Length > 0 && args.Length <= 5 )
            {
                string emailaddress = args[0];
                string password = args[1];
                string subject = args[2];
                string recipient = args[3];
                
                try
                {
                    MailMessage mail = new MailMessage();
                
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress(emailaddress);
                    mail.To.Add(recipient);
                    mail.Subject = subject;
                    mail.Body = Msg.MsgRaw(); 
                    
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(emailaddress, password);
                    SmtpServer.EnableSsl = true;
                
                    SmtpServer.Send(mail);

                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString() + "\n");
                }
            }
        }    
    }
}
