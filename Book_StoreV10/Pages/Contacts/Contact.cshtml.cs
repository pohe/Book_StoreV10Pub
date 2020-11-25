using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Book_StoreV10.Interfaces;
using Book_StoreV10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_StoreV10.Pages.Contacts
{
    public class ContactModel : PageModel
    {
        private readonly IMailService _mailSender;

        public ContactModel(IMailService mailSender)
        {
            _mailSender = mailSender;
        }

        public string Welcome { get; set; }
        [BindProperty]
        public Message Message { get; set; }

        public void OnGet()
        {
            Welcome = "Your contact page.";
        }

        public IActionResult OnPost()
        {
            Message.To = "support@support.dk";
            _mailSender.Send(Message);
            return Redirect("Feedback"); 
        }
       
    }
}
