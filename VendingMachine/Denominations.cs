using System.Reflection;

namespace VendingMachine
{
    public class Denomination
    {
        // Dictionary to map denomination values to property names
        private readonly Dictionary<int, string> denominationMap = new Dictionary<int, string>()
        {
            { 1, "PennyQuantity" },
            {2, "TwoPQuantity" },
            { 5, "FivePQuantity" },
            { 10, "TenPQuantity" },
            { 20, "TwentyPQuantity" },
            { 50, "FiftyPQuantity" },
            { 100, "OnePoundQuantity" },
            { 200, "TwoPoundQuantity" },
            { 500, "FivePoundQuantity" },
            { 1000, "TenPoundQuantity" }
        };

        // Properties for each coin denomination and note value
        public int PennyQuantity { get; set; }
        public int TwoPQuantity { get; set; }
        public int FivePQuantity { get; set; }
        public int TenPQuantity { get; set; }
        public int TwentyPQuantity { get; set; }
        public int FiftyPQuantity { get; set; }
        public int OnePoundQuantity { get; set; }
        public int TwoPoundQuantity { get; set; }
        public int FivePoundQuantity { get; set; }
        public int TenPoundQuantity { get; set; }

        public Denomination()
        {
            // Constructor to set initial values of properties to 0
            PennyQuantity = 0;
            TwoPQuantity = 0;
            FivePQuantity = 0;
            TenPQuantity = 0;
            TwentyPQuantity = 0;
            FiftyPQuantity = 0;
            OnePoundQuantity = 0;
            TwoPoundQuantity = 0;
            FivePoundQuantity = 0;
            TenPoundQuantity = 0;
        }

        /// <summary>
        /// Adds one to the quantity of the specified denomination.
        /// </summary>
        /// <param name="denomination">The denomination to add to, represented as an integer.</param>
        public void AddToBalance(int denomination)
        {
            if (denominationMap.TryGetValue(denomination, out string propertyName))
            {
                // Use reflection to get the property and increment its value by 1
                PropertyInfo property = GetType().GetProperty(propertyName);
                int currentValue = (int)property.GetValue(this);
                property.SetValue(this, currentValue + 1);
            }
        }

        public int CalculateTotal()
        {
            int total = 0;
            foreach (KeyValuePair<int, string> pair in denominationMap)
            {
                PropertyInfo property = GetType().GetProperty(pair.Value);
                int quantity = (int)property.GetValue(this);
                total += pair.Key * quantity;
            }
            return total;
        }

        public void CalculateChange(int change)
        {
            int[] denominations = { 1000, 500, 200, 100, 50, 20, 10, 5, 2, 1};

            foreach (int denomination in denominations)
            {
                if (change >= denomination)
                {
                    int count = change / denomination;
                    change -= count * denomination;

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
        }




    }
}
