using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*======*======*======*======*======*======*======*======*");
            Console.WriteLine("              Welcome to Santas Soda Shop!           ");

            //Array Lists
            ArrayList foodPrices = new ArrayList();
            ArrayList foodNames = new ArrayList();
            ArrayList foodQuantities = new ArrayList();

            Dictionary<string, double> items = new Dictionary<string, double>();
            items.Add("apple", 1.99);
            items.Add("sour apple", 5.99);
            items.Add("pineapple", 10.99);
            items.Add("water", 0.99);
            items.Add("citrus", 3.99);
            items.Add("fruit punch", 2.99);
            items.Add("grape", 1.99);
            items.Add("lime", 3.99);
            items.Add("rockin rasperry", 10.99);
            string[] itemsList = { "apple", "sour apple", "pineapple", "water", "citrus", "fruit punch", "grape", "lime", "rockin rasperry", };
            bool addMoreItems = true;
            while (addMoreItems)
            {
                int count = 1;
                Console.WriteLine("*======*======*======*======*======*======*======*======*");
                foreach (KeyValuePair<string, double> food in items) //This displays the table above, but in a nicer format
                {
                    Console.WriteLine($"|{count}|{food.Key.Substring(0, 1).ToUpper() + food.Key.Substring(1),-16}|{food.Value}");
                    count++;
                }
                Console.WriteLine("*======*======*======*======*======*======*======*======*");
                Console.Write("What would you like to add to your sleigh? ");
                string input = Console.ReadLine().ToLower().Trim();//Even if you enter in capital letters, it will make sure it works
                if (items.ContainsKey(input)) //If the users input matches the options in the shop
                {
                    foodNames.Add(input);
                    foodPrices.Add(items[input]);
                    Console.WriteLine($"You've put {input.Substring(0, 1).ToUpper() + input.Substring(1)} soda in your sleigh which is ${items[input]}");
                }
                else if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7" || input == "8" || input == "9")
                {
                    input = itemsList[Convert.ToInt16(input) - 1]; //Takes users number and converts it into the specified key
                    foodNames.Add(input);
                    foodPrices.Add(items[input]);
                    Console.WriteLine($"\nYou've put {input} soda in your sleigh which is ${items[input]}\n");
                }
                else
                {
                    Console.WriteLine("\nSorry, we do not have that in this soda shop!\n");
                }
                CartCounter(foodNames, foodPrices); //Counts what is currently in the cart
                Console.WriteLine("*======*======*======*======*");
                Console.Write("Would you like to add more sodas to your sleigh? (Y/N): ");
                addMoreItems = Continue(); //Takes yes or no to continues
            }
            Console.WriteLine();
            FinalCart(foodNames, foodPrices); //Shows what is in the final cart.   
            Console.WriteLine();

            Total(foodPrices); //Shows the total prices for everything in the cart

            Average(foodPrices); //Shows the average prices for each item in the cart
            Console.WriteLine();

            double max = double.MinValue;
            double min = double.MaxValue;
            foreach (double i in foodPrices)
            {
                if (max < i)
                {
                    max = i;
                }
                if (min > i)
                {
                    min = i;
                }
            }
            Console.WriteLine($"Your most expensive soda was: ${max}");
            Console.WriteLine($"Your least expensive soda was: ${min}");
            Console.WriteLine("\nThank you for shopping at Santa's Soda Shop!\n");
        }
        private static void CartCounter(ArrayList foodNames, ArrayList foodPrices) //Cart Counter
        {
            Console.WriteLine($"Here is what you have in your sleigh! ");
            Console.WriteLine("*======*======*======*======*");
            for (int i = 0; i < foodPrices.Count; i++)
            {
                Console.WriteLine($"{foodNames[i].ToString().Substring(0, 1).ToUpper() + foodNames[i].ToString().Substring(1),-20}${foodPrices[i]}");
            }
        }
        private static void FinalCart(ArrayList foodNames, ArrayList foodPrices) //Final Cart List
        {
            Console.WriteLine("Here is your sleigh!\n*======*======*======*");
            for (int i = 0; i < foodPrices.Count; i++)
            {
                Console.WriteLine($"{foodNames[i].ToString().Substring(0, 1).ToUpper() + foodNames[i].ToString().Substring(1),-12}${foodPrices[i]}");
            }
            Console.WriteLine("*======*======*======*");
        }
        public static double Total(ArrayList foodPrices) //Total Prices in Cart
        {
            Console.Write("The total price of your sleigh is: ");
            double result = 0;
            Console.WriteLine($"${foodPrices.Cast<double>().Sum()}");
            return result;
        }
        public static double Average(ArrayList foodPrices) //Average Prices in Cart
        {
            Console.Write("The average price of each item is: ");
            double result = 0;

            double cartSize = foodPrices.Count;
            double average = (foodPrices.Cast<double>().Sum() / cartSize);
            Console.Write("${0}", Math.Round(average, 2));

            return result;
        }
        private static bool Continue() //If the user would like to continue or not
        {
            bool valid = true;
            bool repeat = true;
            while (valid)
            {
                string answer = Console.ReadLine().ToLower().Trim();
                if (answer == "y")
                {
                    valid = false;
                    repeat = true;
                }
                else if (answer == "n")
                {
                    valid = false;
                    repeat = false;
                }
                else
                {
                    Console.Write("That was not a valid input. (y/n) ");
                }
            }
            return repeat;
        }
    }
}