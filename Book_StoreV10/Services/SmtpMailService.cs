using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Book_StoreV10.Interfaces;
using Book_StoreV10.Models;

namespace Book_StoreV10.Services
{
    public class SmtpMailService : IMailService
    {
        //https://www.mikesdotnetting.com/article/311/sending-email-in-razor-pages
        //https://www.codeproject.com/Articles/66257/Sending-Mails-in-NET-Framework
        public void Send(Message message)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                smtp.PickupDirectoryLocation = @"C:\Users\EASJ\OneDrive - Zealand Sjællands Erhvervsakademi(1)\Dokumenter\UV\SWC2020E\MineRazorProgrammer\Book_StoreV10\Book_StoreV10\Data\mails";

                var msg = new MailMessage
                {
                    Body = message.Body,
                    Subject = message.Subject,
                    From = new MailAddress(message.From)
                };
                msg.To.Add(message.To);
                smtp.SendMailAsync(msg);
            }
        }
    }
}
