using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_StoreV10.Interfaces;
using Book_StoreV10.Models;
using Book_StoreV10.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_StoreV10.Pages.Orders
{
    public class ShoppingCartModel : PageModel
    {
        public ShoppingCartService ChartService { get; }
        public List<OrderLine> OrderedBooks { get; set; }
        private IBooksRepository repo;

        public Book Book { get; set; }

        public ShoppingCartModel(IBooksRepository repository, ShoppingCartService chart)
        {
            repo = repository;
            ChartService = chart;
            OrderedBooks = new List<OrderLine>();
        }
        public IActionResult OnGet(string isbn)
        {
            Book book = repo.GetBook(isbn);
            ChartService.Add(book);
            OrderedBooks = ChartService.GetOrderedBooks();
            return Page();
        }

        public IActionResult OnPostDelete(string isbn)
        {
            ChartService.RemoveBook(isbn);
            OrderedBooks = ChartService.GetOrderedBooks();
            return Page();
        }

        public IActionResult OnPostUpdate(string isbn)
        {
           //this is the update page
            return Page();
        }

    }
}
