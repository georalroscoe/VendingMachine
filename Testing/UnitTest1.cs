using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Domain;
using Moq;
using System.Transactions;
using System.Data.Common;


namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        private VendingMachine vendingMachine;
        private Order order;




        [TestMethod]

        public (VendingMachine, Order) Test1()
        {
            
            vendingMachine = new VendingMachine("gbp");
            //vendingMachine[100] = 10;
            //var x = vendingMachine[100];
            vendingMachine.AddMoneyBank();
            List<Stock> stockList = new List<Stock>();
            //List<Product> productList = new List<Product>();
            order = new Order(0);

            for (int i = 0; i < 5; i++)
            {
                char productID = (char)(i + 97);
                string productName = $"Product {productID}";
                int productPrice = (i + 1) * 10;
                int productQuantity = i + 1;

                //Product product = new Product(productPrice, productID, productName);
                Stock stock = new Stock(productID, productName, productPrice, productQuantity);
                //stock.AddProduct(product);
                stockList.Add(stock);
                //productDetailsList.Add(productDetails);
            }
            // foreach(Stock product in productList)
            //{
            //    product.AddProducts(productDetailsList);
            //}

            vendingMachine.AddStockList(stockList);
            Assert.AreEqual(5, vendingMachine.Stocks.Count);
            return (vendingMachine, order);

        }

        

        [TestMethod]

        public (VendingMachine, Order) Test2() //testing inserting correct denominations
        {
            (VendingMachine vendingMachine, Order order) = Test1();
           vendingMachine.AddM(100);
            vendingMachine.AttemptAdd(10);
            vendingMachine.AttemptAdd(10);
            Assert.AreEqual(120, order.Balance);
            return (vendingMachine, order);
        }
        [TestMethod]
        public void Test3() //testing purchasing a product 
        {

            (VendingMachine vendingMachine, Order order) = Test2();
            int? beforeQuantity = vendingMachine.Stocks.FirstOrDefault(x => x.ProductId == 'a').Quantity;
            List<int> change = order.Purchase('a');
            List<int> testChange = new List<int> { 100, 10 };
            int? afterQuantity = vendingMachine.Stocks.FirstOrDefault(x => x.ProductId == 'a').Quantity + 1;
            Assert.AreEqual(afterQuantity, beforeQuantity);
            Assert.AreEqual(change[0], testChange[0]);
            //return (vendingMachine, order);


        }

        [TestMethod]
        public void Test4() //testing adding a new product to the stock
        {
            (VendingMachine vendingMachine, Order order) = Test1();
            vendingMachine.AddNewStock('z', "product z", 100, 3);
            Stock? stock = vendingMachine.Stocks.FirstOrDefault(x => x.ProductId == 'z');
            Assert.AreEqual(stock.ProductName, "product z");
        }

        [TestMethod]
        public void Test5() //testing cancelling the order and giving change
        {
            (VendingMachine vendingMachine, Order order) = Test1();
            order.AttemptAdd(10);
            List<int> change = order.Cancel();
            List<int> testChange = new List<int> { 10 };
            Assert.AreEqual(change[0], testChange[0]);
            //return (vendingMachine, order);

        }

        [TestMethod]

        public void Test6() //testing incorect denominations
        {
            (VendingMachine vendingMachine, Order order) = Test1();
            Assert.ThrowsException<Exception>(() => order.AttemptAdd(14));

        }
        [TestMethod]

        public void Test7() //testing adding stock to already existing product
        {
            (VendingMachine vendingMachine, Order order) = Test1();
            vendingMachine.AddToExistingStock('a', 5);
            Stock stock = vendingMachine.Stocks.FirstOrDefault(x => x.ProductId == 'a');
            Assert.AreEqual(stock.Quantity, 6);
        }



    }
}
