using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VendingMachine
{
    public class Transaction
    {
        public enum Denominations
        {
            Penny = 1,
            TwoPence = 2,
            FivePence = 5,
            TenPence = 10,
            TwentyPence = 20,
            FiftyPence = 50,
            OnePound = 100,
            TwoPounds = 200,
            FivePounds = 500,
            TenPounds = 1000
        }



        public List<int> CalculateChange(int remainingBalance)
        {
            List<int> denominations = Enum.GetValues(typeof(Denominations)).Cast<int>().ToList();
            denominations.Sort();
            denominations.Reverse();

            List<int> quantities = new List<int>();
            foreach (int denomination in denominations)
            {
                if (remainingBalance >= denomination)
                {
                    int count = remainingBalance / denomination;
                    remainingBalance -= count * denomination;
                    quantities.Add(count);
                }
                else
                {
                    quantities.Add(0);
                }
            }

            return quantities;
        }

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
                Change = CalculateChange(Balance);
                Success= true;

                

            }
            else
            {
                return;
            }
        }
       
    }
}
