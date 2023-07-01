﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Domain;

public class Stock
{

    public Stock(char productid, string productname, int price, int quantity)
    {

        ProductId = productid;
        Price = price;
        ProductName = productname;
        Quantity = quantity;

    }
    public char ProductId { get; private set; }

    public int Price { get; private set; }

    public string ProductName { get; private set; }

    public int Quantity { get; private set; }

  
    public void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }
    public void RemoveStock()
    {
        Quantity -= 1;
    }
    
   
}
