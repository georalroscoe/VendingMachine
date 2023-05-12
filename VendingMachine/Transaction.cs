using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendingMachine
{
    public class Transaction
    {
        

        
        public int Balance { get; set; }
        public int ProductPrice { get; set; }
        

        public bool Success { get; set; }

        public List<int> Change { get; set; }

        //putting classes as a properrty in another class, also could i do this with product?  

        public Transaction()
        {

        }

        public void AddToBalance(int amount)
        {
            Balance += amount;
        }

        public void SetRequiredPrice(int price)
        {
            ProductPrice = price;
        }

       

       public void Purchase()
        {
            
            if (Balance >= ProductPrice)
            {
               
                Balance -= ProductPrice;
                Denomination denomination = new Denomination();
                Change = denomination.CalculateChange(Balance);
                Success= true;

                

            }
            else
            {
                Denomination denomination = new Denomination();
                Change = denomination.CalculateChange(Balance);
                return;
            }
        }
       
    }
}
