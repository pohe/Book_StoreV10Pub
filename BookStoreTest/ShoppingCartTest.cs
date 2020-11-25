using Book_StoreV10.Models;
using Book_StoreV10.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookStoreTest
{
    [TestClass]
    public class ShoppingCartTest
    {
        private ShoppingCartService sct = new ShoppingCartService();
        public void setUp()
        {
            Book b1 = new Book();
            Book b2 = new Book();
            sct.Add(b1);
            sct.Add(b2);
        }

        [TestMethod]
        public void AddBookTest()
        {
            //Arrange
            int numbersBefore = sct.GetOrderedBooks().Count;
            //Act
            sct.Add(new Book());
            int numbersAfter = sct.GetOrderedBooks().Count;
            //Assert
            Assert.AreEqual(numbersBefore+1, numbersAfter);
        }
    }
}
