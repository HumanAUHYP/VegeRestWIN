using System;
using CoreLibrary;

namespace VegeRestConsoleApp
{
    class Program
    {
        private string path = @"C:\Users\Human\source\repos\VegeRest\CoreLibrary\data\orders.txt";
        MenuStorage orderStorage;
        static void Main(string[] args)
        {
            
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Waiter");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                orderStorage.ReadFromFile(path);
                var orders = orderStorage.Menues;
                Console.WriteLine("");
            }
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Waiter");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                orderStorage.ReadFromFile(path);
                var orders = orderStorage.Menues;
                Console.WriteLine("");
            }
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Waiter");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                orderStorage.ReadFromFile(path);
                var orders = orderStorage.Menues;
                Console.WriteLine("");
            }
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Waiter");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                orderStorage.ReadFromFile(path);
                var orders = orderStorage.Menues;
                Console.WriteLine("");
            }
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Waiter");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                orderStorage.ReadFromFile(path);
                var orders = orderStorage.Menues;
                Console.WriteLine("");
            }
        }
    }
}
