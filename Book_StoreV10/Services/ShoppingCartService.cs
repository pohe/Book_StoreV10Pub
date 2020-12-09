using Book_StoreV10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_StoreV10.Services
{
    public class ShoppingCartService
    {
        // This service should be implemented 

        List<OrderLine> _cartItems;
        public ShoppingCartService()
        {
            _cartItems = new List<OrderLine>();
        }
        public void Add(Book book)
        {
            OrderLine  oLine = findOrderline(book.ISBN);
            if (oLine == null)
            {
                OrderLine oline = new OrderLine(book, 1);
                _cartItems.Add(oline);
            }
            else
            {
                updateOrderline(book.ISBN);
            }
            
        }

        private void updateOrderline(string isbn)
        {
            foreach (OrderLine orderLine in _cartItems)
            {
                if (orderLine.Book.ISBN == isbn)
                    orderLine.Amount++;
            }
        }

        private OrderLine findOrderline(string isbn)
        {
            foreach (OrderLine orderLine in _cartItems)
            {
                if (orderLine.Book.ISBN == isbn)
                    return orderLine;
            }
            return null; 
        }

        public List<OrderLine> GetOrderedBooks()
        {
            return _cartItems;
        }

        public void RemoveBook(string isbn)
        {
            foreach (OrderLine line in _cartItems)
            {
                if (line.Book.ISBN == isbn)
                {
                    if (line.Amount <= 1)
                        _cartItems.Remove(line);
                    if (line.Amount > 1)
                        line.Amount = line.Amount - 1;
                    
                    break;
                }
            }
        }

        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0.00M;

            foreach (var v in _cartItems)
            {
                totalPrice = totalPrice + (decimal)v.Book.Price* v.Amount;
            }
            return totalPrice;
        }
    }
}
