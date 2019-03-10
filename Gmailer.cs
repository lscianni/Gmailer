using System;
using System.Net.Mail;
/*
 * Copyright (c) 2019 Louis Scianni
 *
 * This program is free software; you can redistribute it and/or modify it 
 * under the terms of the GNU General Public License as published by the
 * Free Software Foundation; either version 2 of the License, or 
 * (at your option) any later versino.
 *
 * This program is distributed in the hope that it will be useful, but
 * WITHOUT ANY WARRANTY; without even the implied warranty of MECHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOS. See the GNU General Public License for
 * more details.
 *
 * You should received a copy of the GNU Genearl Public License along with
 * this program; if not write to the Free Software Foundation, Inc.,
 * 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 *
 * lscianniit@gmail.com
 */
namespace GmailerConsoleApplication
{    
    public class MsgBody
    {
	/*Get the message to send*/
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
            /*If no arguments are given tell the use what to do*/
            if (args.Length == 0)
            {
                Console.WriteLine("gmailer \nsend emails using a gmail account");
                Console.WriteLine("Usage: gmailer.exe [emailaddress] [password] [subject] [recipient]");
                
            }
            /*If we get the right amount of arguments get ready to send*/
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
                    
                    Char delimter = ',';
                
                    String[] substrings = recipient.Split(delimter);
                
                    foreach (var substring in substrings)
                    {
                        mail.To.Add(substring);
                    }
                    
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
