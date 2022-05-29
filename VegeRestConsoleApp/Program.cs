using System;
using CoreLibrary;

namespace VegeRestConsoleApp
{
    class Program
    {
        private static string menuPath = @"..\..\..\..\CoreLibrary\data\menu.txt";
        private static string orderPath = @"..\..\..\..\CoreLibrary\data\orders.txt";
        private static string reportPath = @"..\..\..\..\CoreLibrary\data\Reports\";
        private static MenuStorage menuStorage;
        private static OrderStorage orderStorage;
        static void Main(string[] args)
        {
            menuStorage = new MenuStorage();
            orderStorage = new OrderStorage();
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
                    case "2":
                        IncorrectAnswer = false;
                        ClientInit();
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
        
        public static void ClientInit()
        {
            Console.WriteLine("Enter client name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter table num");
            var tableNum = Console.ReadLine();
            ClientStorage.Add(new Client($"1;{name};{tableNum}"));
            ClientMenu();
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
                        ViewOrder();
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
            try
            {
                Console.WriteLine("Enter menu Id for add to order");
                var id = Console.ReadLine();
                var menu = menuStorage.FindById(id);
                var order = new Order();
                order.Name = menu.Name;
                order.Price = menu.Price;
                order.ClientId = ClientStorage.Clients[0].Id;
                Console.WriteLine("Choice cooking option");
                foreach(var option in CookingOptions.Options)
                {
                    Console.WriteLine(option.Title);
                }
                order.CookingOption = Console.ReadLine();
                Console.WriteLine("Choice cutting option");
                foreach (var option in CuttingOptions.Options)
                {
                    Console.WriteLine(option.Title);
                }
                order.CuttingOption = Console.ReadLine();
                Console.WriteLine("Enter count");
                order.Count = int.Parse(Console.ReadLine());
                order.Price *= order.Count;
                orderStorage.Add(order);
                orderStorage.WriteInFile(orderPath);
                ClientMenu();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ClientMenu();
            }
        }

        public static void ViewOrder()
        {
            if (orderStorage.Orders.Count == 0)
            {
                Console.WriteLine("Order is empty");
                ClientMenu();
            }
            foreach (var order in orderStorage.Orders)
            {
                Console.WriteLine(order);
            }
            string answer;
            bool IncorrectAnswer = true;
            while (IncorrectAnswer)
            {
                Console.WriteLine("1. Remove order");
                Console.WriteLine("2. Change order");
                Console.WriteLine("3. Chekout");
                Console.WriteLine("4. Back");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        IncorrectAnswer = false;
                        RemoveOrder();
                        break;
                    case "2":
                        IncorrectAnswer = false;
                        ChangeOrder();
                        break;
                    case "3":
                        IncorrectAnswer = false;
                        Chekout();
                        break;
                    case "4":
                        IncorrectAnswer = false;
                        ClientMenu();
                        break;
                    default:
                        Console.WriteLine("Incorrect answer, please try again.");
                        break;
                }
            }
        }

        public static void ChangeOrder()
        {
            try
            {
                Console.WriteLine("Enter order Id for change");
                var id = Console.ReadLine();
                Console.WriteLine("Enter order in format [cooking option];[cutting option];[count]");
                var data = Console.ReadLine().Split(';');
                var order = new Order();
                order.Id = int.Parse(id);
                order.CookingOption = data[0];
                order.CuttingOption = data[1];
                order.Count = int.Parse(data[2]);
                orderStorage.FindById(id).Price /= orderStorage.FindById(id).Count;
                orderStorage.Change(order);
                ViewOrder();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ViewOrder();
            }
        }

        public static void RemoveOrder()
        {
            try
            {
                Console.WriteLine("Enter order Id for remove");
                var id = Console.ReadLine();
                orderStorage.RemoveById(id);
                ViewOrder();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ViewOrder();
            }
        }

        public static void Chekout()
        {
            orderStorage.WriteInFile(reportPath + $"Table{ClientStorage.Clients[0].TableNum}.txt");
            orderStorage.Orders.Clear();
            ClientMenu();
        }
    }
}
