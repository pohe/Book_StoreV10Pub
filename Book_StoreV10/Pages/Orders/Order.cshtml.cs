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
    public class OrderModel : PageModel
    {

        private JsonOrderRepository repository;

        private ShoppingCartService cart;


        public string SalesInfo { get; set; }
        public Student Student { get; set; }
        public Order Order { get; set; }
        public List<Book> cartItems { get; set; }

        public OrderModel(JsonOrderRepository repoService, ShoppingCartService cartService)
        {
            repository = repoService;
            cart = cartService;
        }

        public IActionResult OnGet(Student st)
        {
            SalesInfo = $"We have sent and email to {st.Email}  about the order "; 
            Student = st;
            cartItems = cart.GetOrderedBooks();
            if (cartItems?.Count() <= 0)
            {
                return Redirect("ShoppingCart");
            }
            return Page();
        }
    }
}
