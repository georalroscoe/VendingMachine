using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public char Productid { get; set; }

        public int Quantity { get; set; }
        

        public Product (string name, int price, char productid, int quantity)
        {
            Name = name;
            Price = price;
            Productid = productid;
            Quantity = quantity;
           
        }
        public virtual VendingMachine VendingMachine { get; set; }
    }
}
