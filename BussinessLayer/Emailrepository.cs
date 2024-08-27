using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace SendingMail
{
    public class Mailsending
    {

        private readonly IConfiguration Configuration;


        public Mailsending(IConfiguration configuration)
        {
           
            Configuration = configuration;
        }

       



        public void SendEmail( string fromAddress, string password ,string toAddress ,string Subject , string Body)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(fromAddress, password)

            };
            

            try
            {
                Console.WriteLine("sending email **********");
                email.Send(fromAddress, toAddress, Subject, Body);
                Console.WriteLine("email sent");

            }
            catch (SmtpException e)
            {
                throw;
            }


        }


        


    }
}
