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

        public virtual VendingMachine VendingMachine { get; set; }

        public Transaction(int balance, int productId) {
            Balance= balance;
            ProductId = productId;
            Success = false;


        }

        public void Purchase(Product prod)
        {
            
            if (this.Balance > prod.Price)
            {
                prod.Quantity -= 1;
                Balance -= prod.Price;
                Change = new Denomination();
                Change.CalculateChange(this.Balance);
                this.Success = true;

            }
            else
            {
                return;
            }
        }

    }
}
