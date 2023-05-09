using System;


namespace VendingMachine 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> denominations = new HashSet<int> { 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000 };
            HashSet<char> products = new HashSet<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            var balance = new Denomination();
            var prod = new Product("apple", 150, 'a', 10);

            do {
                Console.WriteLine("Input money or product selection");

                string input = Console.ReadLine();

                int number;

                if (int.TryParse(input, out number))
                {
                    if (denominations.Contains(number))
                    {
                        balance.AddToBalance(number);
                        Console.WriteLine($"You entered the number: {number}");
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
                    if (products.Contains(productId))
                    {
                        var transaction = new Transaction(balance.CalculateTotal(), productId);
                        transaction.Purchase(prod);
                        if (transaction.Success)
                        {
                           
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