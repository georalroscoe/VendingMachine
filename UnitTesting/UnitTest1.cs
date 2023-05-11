using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using VendingMachine;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        
        public void TestAddProductsToList()
        {
            // arrange
            VendingMachine.VendingMachine vendingMachine = new VendingMachine.VendingMachine();
            List<Product> productList = new List<Product>();

            for (int i = 0; i < 5; i++)
            {
                char productID = (char)(i + 97); // ASCII code for lowercase 'a' is 97
                string productName = $"Product {productID}";
                int productPrice = (i + 1) * 10;
                int productQuantity = i + 1;

                Product product = new Product(productName, productPrice, productID, productQuantity);
                productList.Add(product);
            }

            // act
            vendingMachine.AddProducts(productList);

            // assert
            Assert.AreEqual(vendingMachine.GetProductsCount(), 5);
            for (int i = 0; i < 5; i++)
            {
                char productID = (char)(i + 97);
                Assert.IsTrue(vendingMachine.HasProduct(productID));
            }
        }

    }
}
