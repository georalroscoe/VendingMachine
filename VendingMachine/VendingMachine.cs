using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter.Xml;
using Domain;

namespace Domain;

public class VendingMachine
{

    public VendingMachine(Dictionary<int, int> denominationQuantities)
    {
       
        Stocks = new List<Stock>();
        DenominationQuantities = denominationQuantities;
       
    }

    public Dictionary<int, int> DenominationQuantities { get; private set; }

    public int Balance { get; private set; }


    public List<Stock> Stocks { get; private set; }

    public string SelectProduct(char productId)
    {
        Stock? stock = Stocks.FirstOrDefault(x => x.ProductId == productId);
        if (stock == null)
        {
            return "no matching product";
        }
        if (stock.Quantity== 0)
        {
            return "No stock";
        }
        if (stock.Price >= Balance)
        {
            return "Insufficient Balance";
        }

        Balance -= stock.Price;
        

        stock.RemoveStock();

        return $"Here is your {stock.ProductName}";

    }

    public void AddNewStock(char productId, string productName, int price, int quantity)
    {
        Stock stock = new Stock(productId, productName, price, quantity);
        Stocks.Add(stock);
    }

    public List<int> CalculateChange()
    {
        //FillQuantities();
        List<int> changeDenominations = new List<int>();

        foreach (var denomination in DenominationQuantities.Keys.OrderByDescending(k => k))
        {
            int quantity = DenominationQuantities[denomination];
            int denominationCount = Balance / denomination;

            if (denominationCount > 0 && quantity > 0)
            {
                int actualCount = Math.Min(denominationCount, quantity);
                DenominationQuantities[denomination] -= actualCount;

                Balance -= (actualCount * denomination);

                for (int i = 0; i < actualCount; i++)
                {
                    changeDenominations.Add(denomination);
                }
            }

            if (Balance == 0)
                break;
        }

        //if (Balance == 0)
        //{

        return changeDenominations;
        //}
        //else
        //{
        //    throw new Exception("insufficient change in machine");

        //}
    }

    public void AddToExistingStock(char productId, int quantity)
    {
        Stock stock = Stocks.FirstOrDefault(x => x.ProductId == productId);
        if (stock == null)
        {
            throw new Exception("product does not exist for this vending machine");
        }
        else
        {
            stock.AddQuantity(quantity);
        }
    }
    //public void AddMoneyBank()
    //{
    //    if (Currency.ToLower() == "gbp")
    //    {
    //        DenominationQuantities = new Dictionary<int, int>()
    //        {
    //            { 1, 0 },
    //            { 2, 0 },
    //            { 5, 0 },
    //            { 10, 0 },
    //            { 20, 0 },

    //            { 50, 0 },

    //            { 100, 0 },
    //            { 200, 0 },
    //            { 500, 0 }


    //        };
    //    }
    //    else if (Currency.ToLower() == "usd")
    //    {
    //        DenominationQuantities = new Dictionary<int, int>()
    //        {
    //            { 1, 0 },
    //            { 5, 0 },
    //            { 10, 0 },
    //            { 25, 0 },
    //            { 50, 0 },

    //            { 100, 0 },

    //            { 500, 0 }


    //        };
    //    }

    //}

  
    public void AddStockList(List<Stock> stockList)
    {
        Stocks = stockList;
    }

    
    public string AddMoney(int denomination)
    {
        if (DenominationQuantities.ContainsKey(denomination))
        {
            DenominationQuantities[denomination]++;
            Balance += denomination;
            return ($"You have inserted {denomination} and your balance is now {Balance}");
        }
        else
        {
            return "incorrect denomination";
        }
       
    }

    private void FillQuantities()
    {
        foreach (var denomination in DenominationQuantities.Keys.ToList())
        {
            DenominationQuantities[denomination] = 1;
        }


    }

    public void AddToBalance(int amount)
    {
        Balance += amount;
    }

}