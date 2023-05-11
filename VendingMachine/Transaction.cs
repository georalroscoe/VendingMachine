using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendingMachine
{
    internal class Transaction
    {
        
        public int Balance { get; set; }
        public int ProductId { get; set; }
        

        public bool Success { get; set; }

        public Denomination Change { get; set; }

        //putting classes as a properrty in another class, also could i do this with product?  

        public virtual VendingMachine VendingMachine { get; set; }

        public Transaction(int balance, int productId) {
            Balance= balance;
            ProductId = productId;
            Success = false;


        }

       /* public void Purchase(Product product)
        {
            
            if (this.Balance > product.Price)
            {
                product.Quantity -= 1;
                Balance -= product.Price;
                Change = new Denomination();
                Change.CalculateChange(this.Balance);
                this.Success = true;

            }
            else
            {
                return;
            }
        }
       */
    }
}
