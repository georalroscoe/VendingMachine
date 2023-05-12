using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class VendingMachine
    {
        public VendingMachine() {
            

        }
        public int VendingMachineId { get; set; }

        public Transaction Transaction { get; set; }

      
            private List<Product> _productList = new List<Product>();

           

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

        public void CheckForTransaction()
        {
            if (Transaction == null)
            {
                Transaction = new Transaction();
            }
            else
            {
                return;
            }
        }

        public void AddMoney(int money)
        {
            CheckForTransaction();
            Denomination denomination= new Denomination();
            
           
            if (denomination.IsDenomination(money))
            {
                Transaction.AddToBalance(money);
            }
        }

        public void ProductSelection(char purchaseID)
        {
            CheckForTransaction();
            Product? product = _productList.FirstOrDefault(x => x.Productid == purchaseID);
            if (product == null)
            {
                return;
            }
            Transaction.SetRequiredPrice(product.Price);
            Transaction.Purchase();
            if (Transaction.Success)
            {
                product.Quantity -= 1;
            }
            else
            {
                return;
                throw new Exception("transaction unsuccessful");
            }

        }


        



        //stock the vending machine with products and add this to a list on this class
        //input money with testing
        //add money to transaction balance, create new one if no instance already
        //attmept to buy a product in the transaction using testing
        //use the same logic to calcualt the change and put it in a list, update abalance and product quantity 




       
       
        
    }
}
