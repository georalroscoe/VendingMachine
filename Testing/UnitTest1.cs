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
        private VendingMachine InitializeVendingMachine()
        {
            Dictionary<int, int> denominationQuantities = new Dictionary<int, int>()
            {
                { 1, 0 },
                { 2, 0 },
                { 5, 0 },
                { 10, 0 },
                { 20, 0 },
                { 50, 0 },
                { 100, 0 },
                { 200, 0 },
                { 500, 0 }
            };

            VendingMachine vendingMachine = new VendingMachine(denominationQuantities);
            

            List<Stock> stockList = new List<Stock>();

            for (int i = 0; i < 5; i++)
            {
                char productID = (char)(i + 97);
                string productName = $"Product {productID}";
                int productPrice = (i + 1) * 10;
                int productQuantity = i + 1;

                Stock stock = new Stock(productID, productName, productPrice, productQuantity);
                stockList.Add(stock);
            }

            vendingMachine.AddStockList(stockList);

            
            Assert.AreEqual(5, vendingMachine.Stocks.Count);

            return vendingMachine;
        }



        

        [TestMethod]
        public void InsertCorrectDenominationsAndTestBalance() 
        {
            VendingMachine vendingMachine = InitializeVendingMachine();
            vendingMachine.AddMoney(100);
            vendingMachine.AddMoney(10);
            vendingMachine.AddMoney(10);
            Assert.AreEqual(120, vendingMachine.Balance);
            Assert.AreEqual(1, vendingMachine.DenominationQuantities[100]);
            Assert.AreEqual(2, vendingMachine.DenominationQuantities[10]);
            
        }
        [TestMethod]
        public void SelectProductAndTestQuantityAndBalance()  
        {

            VendingMachine vendingMachine = InitializeVendingMachine();
            vendingMachine.AddMoney(200);
            Stock stock = vendingMachine.Stocks.FirstOrDefault(x => x.ProductId == 'a');
            int? beforeQuantity = stock.Quantity;
            vendingMachine.SelectProduct('a');
            int? afterQuantity = stock.Quantity + 1;
            Assert.AreEqual(afterQuantity, beforeQuantity);
            Assert.AreEqual(vendingMachine.Balance, 200 - stock.Price);
            
        }
        [TestMethod]
        public void SelectOutOfQuantityProduct()
        {

            VendingMachine vendingMachine = InitializeVendingMachine();
            vendingMachine.AddMoney(200);
            Stock? stock = vendingMachine.Stocks.FirstOrDefault(x => x.ProductId == 'a');
            stock.RemoveStock();
            vendingMachine.SelectProduct('a');
            string errorMessage = vendingMachine.SelectProduct('a');
            Assert.AreEqual(errorMessage, "No stock");
            Assert.AreEqual(vendingMachine.Balance, 200);

        }
        [TestMethod]
        public void SelectInvalidProduct()
        {

            VendingMachine vendingMachine = InitializeVendingMachine();
            vendingMachine.AddMoney(200);
            Stock? stock = vendingMachine.Stocks.FirstOrDefault(x => x.ProductId == 'q');
            if (stock != null)
            {
                stock.RemoveStock();
            }
            vendingMachine.SelectProduct('q');
            string errorMessage = vendingMachine.SelectProduct('q');
            Assert.AreEqual(errorMessage, "no matching product");
            Assert.AreEqual(vendingMachine.Balance, 200);

        }


        [TestMethod]
        public void AddProductAndTestItsThere()
        {
            VendingMachine vendingMachine = InitializeVendingMachine();
            vendingMachine.AddNewStock('z', "product z", 100, 3);
            Stock? stock = vendingMachine.Stocks.FirstOrDefault(x => x.ProductId == 'z');
            Assert.AreEqual(stock.ProductId, 'z');
        }

        [TestMethod]
        public void RequestChangeAndCheckIfValid() 
        {
            VendingMachine vendingMachine = InitializeVendingMachine();
            vendingMachine.AddMoney(10);
            List<int> change = vendingMachine.CalculateChange();
            List<int> testChange = new List<int> { 10 };
            Assert.AreEqual(change[0], testChange[0]);
            

        }

        [TestMethod]
        public void RequestChangeThatIsNotInMoneyBank()
        {
            VendingMachine vendingMachine = InitializeVendingMachine();
            vendingMachine.AddToBalance(200); //adding to balance but not money bank
            vendingMachine.AddMoney(10);
            vendingMachine.AddMoney(20);
            vendingMachine.AddMoney(5);
            List<int> change = vendingMachine.CalculateChange();//should return the max amount of change possible
            List<int> testChange = new List<int> { 20, 10, 5 };
            Assert.AreEqual(change[0], testChange[0]); 


        }



        [TestMethod]

        public void InsertIncorrectDenominationAndTestError()
        {
            VendingMachine vendingMachine = InitializeVendingMachine();
            string errorMessage = vendingMachine.AddMoney(14);
            Assert.AreEqual(errorMessage, "incorrect denomination");


        }
        [TestMethod]

        public void LoadStockAndTestQuantity() 
        {
            VendingMachine vendingMachine = InitializeVendingMachine();
            vendingMachine.AddToExistingStock('a', 5); // product 'a' is initialised with a quantity of 1
            Stock stock = vendingMachine.Stocks.FirstOrDefault(x => x.ProductId == 'a');
            Assert.AreEqual(stock.Quantity, 6);
        }



    }
}
