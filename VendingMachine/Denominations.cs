using System.Reflection;

namespace VendingMachine
{
    public class Denomination
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


       /*
        public void CalculateChange(int remainingBalance)
        {
            int[] denominations = { 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1};

            foreach (int denomination in denominations)
            {
                if (remainingBalance >= denomination)
                {
                    int count = remainingBalance / denomination;
                    remainingBalance -= count * denomination;

                    switch (denomination)
                    {
                        case 1000:
                            TenPoundQuantity = count;
                            break;
                        case 500:
                            FivePoundQuantity = count;
                            break;
                        case 200:
                            TwoPoundQuantity = count;
                            break;
                        case 100:
                            OnePoundQuantity = count;
                            break;
                        
                        
                        case 50:
                            FiftyPQuantity = count;
                            break;
                        case 20:
                            TwentyPQuantity = count;
                            break;
                        case 10:
                            TenPQuantity = count;
                            break;
                        case 5:
                            FivePQuantity = count;
                            break;
                        case 2:
                            TwoPQuantity = count;
                            break;
                        case 1:
                            PennyQuantity = count;
                            break;
                    }
                }
            }
        }*/




    }
}
