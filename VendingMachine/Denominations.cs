using System.Reflection;

namespace VendingMachine
{
    public class Denomination
    {
        public Denomination() { }
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

        public bool IsDenomination(int value)
        {
            return Enum.IsDefined(typeof(Denominations), value);
        }


        public List<int> CalculateChange(int remainingBalance)
        {
            List<int> denominations = Enum.GetValues(typeof(Denominations)).Cast<int>().ToList();
            
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






    }
}
