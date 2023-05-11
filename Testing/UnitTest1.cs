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
                 char productID = (char)(i + 97); 
                 string productName = $"Product {productID}";
                 int productPrice = (i + 1) * 10;
                 int productQuantity = i + 1;

                 Product product = new Product(productName, productPrice, productID, productQuantity);
                 productList.Add(product);
             }

            

             // act
             vendingMachine.AddProducts(productList);

            Assert.AreEqual(5, vendingMachine.ProductList.Count);

            // assert
            Assert.AreEqual(vendingMachine.GetProductsCount(), 5);
             for (int i = 0; i < 5; i++)
             {
                 char productID = (char)(i + 97);
                 Assert.IsTrue(vendingMachine.HasProduct(productID));
             }


            vendingMachine.AddMoney(200);
            vendingMachine.AddMoney(100);
            vendingMachine.AddMoney(1);

            vendingMachine.ProductSelection('a');

            var prod = productList.FirstOrDefault(x => x.Productid == 'a');

            var change = vendingMachine.Transaction.Change;

            Assert.AreEqual(0, change[0]);

            Assert.AreEqual(0, prod.Quantity);
            // Assert that the vending machine's balance has been updated correctly
            Assert.AreEqual(340, vendingMachine.Transaction.Balance);
            


        }


    }
}
