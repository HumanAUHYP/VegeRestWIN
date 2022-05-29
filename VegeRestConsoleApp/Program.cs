using System;
using CoreLibrary;

namespace VegeRestConsoleApp
{
    class Program
    {
        public static string menuPath = @"..\..\..\..\CoreLibrary\data\menu.txt";
        public static MenuStorage menuStorage;
        static void Main(string[] args)
        {
            menuStorage = new MenuStorage();
            Init();
            
        }
        public static void Init()
        {
            string answer;
            bool IncorrectAnswer = true;
            while (IncorrectAnswer)
            {
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Client");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        IncorrectAnswer = false;
                        AdminMenu();
                        break;

                    default:
                        Console.WriteLine("Incorrect answer, please try again.");
                        break;
                }
            }
        }
        public static void AdminMenu()
        {
            menuStorage.ReadFromFile(menuPath);
            foreach (var menu in menuStorage.Menues)
            {
                Console.WriteLine(menu);
            }
            string answer;
            bool IncorrectAnswer = true;
            while (IncorrectAnswer)
            {
                Console.WriteLine("1. Add new menu pos");
                Console.WriteLine("2. Change menu pos");
                Console.WriteLine("3. Remove menu pos");
                Console.WriteLine("4. Back");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        IncorrectAnswer = false;
                        AddMenu();
                        break;
                    case "2":
                        IncorrectAnswer = false;
                        ChangeMenu();
                        break;
                    case "3":
                        IncorrectAnswer = false;
                        RemoveMenu();
                        break;
                    case "4":
                        IncorrectAnswer = false;
                        Init();
                        break;
                    default:
                        Console.WriteLine("Incorrect answer, please try again.");
                        break;
                }
            }
        }
        public static void AddMenu()
        {
            try
            {
                Console.WriteLine("Enter menu in format [name];[description];[image];[price]");
                var str = Console.ReadLine();
                var menu = new Menu("0;" + str);
                menuStorage.Add(menu);
                menuStorage.WriteInFile(menuPath);
                AdminMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                AdminMenu();
            }
        }

        public static void ChangeMenu()
        {
            try
            {
                Console.WriteLine("Enter menu Id for change");
                var id = Console.ReadLine();
                Console.WriteLine("Enter menu in format [name];[description];[image];[price]");
                var str = Console.ReadLine();
                var menu = new Menu(id + ";" + str);
                menuStorage.Change(menu);
                menuStorage.WriteInFile(menuPath);
                AdminMenu();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                AdminMenu();
            }
        }

        public static void RemoveMenu()
        {
            try
            {
                Console.WriteLine("Enter menu Id for remove");
                var id = Console.ReadLine();
                menuStorage.RemoveById(id);
                menuStorage.WriteInFile(menuPath);
                AdminMenu();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                AdminMenu();
            }
        }

        public static void ClientMenu()
        {
            menuStorage.ReadFromFile(menuPath);
            foreach (var menu in menuStorage.Menues)
            {
                Console.WriteLine(menu);
            }
            string answer;
            bool IncorrectAnswer = true;
            while (IncorrectAnswer)
            {
                Console.WriteLine("1. Add to order");
                Console.WriteLine("2. View my order");
                Console.WriteLine("3. Back");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        IncorrectAnswer = false;
                        AddOrder();
                        break;
                    case "2":
                        IncorrectAnswer = false;
                        ChangeMenu();
                        break;
                    case "3":
                        IncorrectAnswer = false;
                        Init();
                        break;
                    default:
                        Console.WriteLine("Incorrect answer, please try again.");
                        break;
                }
            }
        }

        public static void AddOrder()
        {

        }
    }
}
