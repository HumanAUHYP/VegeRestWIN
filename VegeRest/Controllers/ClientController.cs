using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLibrary;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VegeRest.Controllers
{
    public class ClientController : Controller
    {
        private string menuPath = @"..\CoreLibrary\data\menu.txt";
        private string ordersPath = @"..\CoreLibrary\data\orders.txt";

        // ссылка на объект - хранилище заказов и хранилище клиентов
        MenuStorage menuStorage;
        OrderStorage orderStorage;

        public ClientController(IMenuStorage _menuStorage, IOrderStorage _orderStorage)
        {
            menuStorage = (MenuStorage)_menuStorage;
            orderStorage = (OrderStorage)_orderStorage;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            menuStorage.ReadFromFile(menuPath);
            return View(menuStorage.Menues);
        }

        [HttpPost]
        public IActionResult SaveClient(Client client)
        {
            ClientStorage.Add(client);
            return RedirectToAction("Menu");
        }

        public IActionResult Options(string id)
        {
            return View(new Order(id, menuStorage.FindById(id)));
        }

        public IActionResult AddToOrder(Order order)
        {
            orderStorage.Add(order);
            orderStorage.WriteInFile(ordersPath);
            return RedirectToAction("Menu");
        }

        public IActionResult Order()
        {
            //orderStorage.ReadFromFile(ordersPath);
            return View(orderStorage.Orders);
        }

        public IActionResult Remove(string id)
        {
            orderStorage.RemoveById(id);
            return RedirectToAction("Basket");
        }
    }
}
