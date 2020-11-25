using Book_StoreV10.Models;
using Book_StoreV10.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ShoppingCartTest1
    {
        private ShoppingCartService scs;

        private void setUp()
        {
            scs = new ShoppingCartService();
            scs.Add(new Book());
            Book b1 = new Book();
            scs.Add(b1);
        }

        [TestMethod]
        public void AddToShoppingCartTest()
        {
            //Arrange
            setUp();
            int numbersBefore = scs.GetOrderedBooks().Count;

            //Act

            scs.Add(new Book());
            int numbersAfter = scs.GetOrderedBooks().Count;
            //Assert
            Assert.AreEqual(numbersAfter, numbersBefore+1);

        }
    }
}
