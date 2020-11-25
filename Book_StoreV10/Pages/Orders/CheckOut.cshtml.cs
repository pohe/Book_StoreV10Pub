using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_StoreV10.Interfaces;
using Book_StoreV10.Models;
using Book_StoreV10.Repositories;
using Book_StoreV10.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_StoreV10.Pages.Orders
{
    public class CheckOutModel : PageModel
    {
        private JsonOrderRepository repository;

        private ShoppingCartService cart;

        [BindProperty]
        public Student Student { get; set; }
        public Order Order { get; set; }

        private readonly IMailService _mailSender;
        public CheckOutModel(JsonOrderRepository repo, ShoppingCartService cartService, IMailService mailSender)
        {
            repository = repo;
            cart = cartService;
            _mailSender = mailSender;
        }
        public void OnGet()
        {
            //Student s = Student;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Order order = new Order();
            order.OrderID = 12;
            order.Student = Student;
            order.Books = cart.GetOrderedBooks();
            order.DateTime = DateTime.Now;
            repository.AddOrder(order);
            sendEmail(order);

            return RedirectToPage("Order", Student);
        }

        public void sendEmail(Order order)
        {
            Message m = new Message();
            m.To = Student.Email;
            m.From = "company@mail.dk";
            m.Subject = "Order information";
            m.Body = $"<p>{order.OrderID} </BR> {order.Student.ToString()} Order info : </BR>  {cart.GetOrderedBooks() } total {cart.CalculateTotalPrice()}";
            m.IsHtml = true; 
            _mailSender.Send(m);
        }
    }
}
