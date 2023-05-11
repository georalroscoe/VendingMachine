using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachine
    {
        public VendingMachine(int vendingMachineId) {
            VendingMachineId = vendingMachineId;

        }
        public int VendingMachineId { get; set; }

      
            private List<Product> _productList = new List<Product>();

            // other code omitted for brevity

            public void AddProducts(List<Product> products)
            {
                _productList.AddRange(products);
            }

            public int GetProductsCount()
            {
                return _productList.Count;
            }

            public bool HasProduct(char productID)
            {
                return _productList.Any(p => p.Productid == productID);
            }

            public List<Product> ProductList
            {
                get { return _productList; }
            }
        



        //stock the vending machine with products and add this to a list on this class
        //input money with testing
        //add money to transaction balance, create new one if no instance already
        //attmept to buy a product in the transaction using testing
        //use the same logic to calcualt the change and put it in a list, update abalance and product quantity 




       
       
        
    }
}
