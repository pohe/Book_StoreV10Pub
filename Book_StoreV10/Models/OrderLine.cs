using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_StoreV10.Models
{
    public class OrderLine
    {
        public Book Book { get; set; }
        public int Amount { get; set; }

        public OrderLine()
        {
            
        }
        public OrderLine(Book book, int amount)
        {
            Book = book;
            Amount = amount;
        }
    }
}
