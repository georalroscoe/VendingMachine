using System;
using System.Linq;


namespace VendingMachine 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> validDenominations = new HashSet<int> { 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000 };
            HashSet<char> validProducts = new HashSet<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            var balance = new Denomination();
            List<Product> productList = new List<Product>();
            productList.Add(new Product("Product A", 100, 'a', 10));
            productList.Add(new Product("Product B", 200, 'b', 5));
            productList.Add(new Product("Product C", 150, 'c', 8));
            
            

            do {
                Console.WriteLine("Input money or product selection");

                string input = Console.ReadLine();

                int number;

                if (int.TryParse(input, out number))
                {
                    if (validDenominations.Contains(number))
                    {
                        balance.AddToBalance(number);
                        
                        //logic
                    }
                    else
                    {
                        Console.WriteLine("not a valid denomination");
                        //try again
                    }
                }
                else if (input.Length == 1)
                {
                    
                   char productId = input[0];
                    if (validProducts.Contains(productId))
                    {
                        var transaction = new Transaction(balance.CalculateTotal(), productId);
                        var product = productList.FirstOrDefault(x => x.Productid == productId);
                        transaction.Purchase(product);
                        if (transaction.Success)
                        {
                            Console.WriteLine($"{transaction.Change.FiftyPQuantity} 60p");
                            return;
                         
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid denomination or product selection.");
                }


            }
            while (true);


        }
    }
}


