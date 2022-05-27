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
        private IWebHostEnvironment Environment;
        private string menuPath = @"..\CoreLibrary\data\menu.txt";

        // ссылка на объект - хранилище заказов и хранилище клиентов
        MenuStorage menuStorage;

        public ClientController(IWebHostEnvironment _environment, IMenuStorage _menuStorage)
        {
            menuStorage = (MenuStorage)_menuStorage;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Menu()
        {
            menuStorage.ReadFromFile(menuPath);
            var menues = menuStorage.Menues;
            return View(menues);
        }

        [HttpPost]
        public IActionResult SaveClient(Client client)
        {
            ClientStorage.Add(client);
            return RedirectToAction("Menu");
        }

        public IActionResult Options(string id)
        {
            Menu selectedMenu = menuStorage.FindById(id);
            Order order = new Order();
            order.MenuId = int.Parse(id);
            order.Image = selectedMenu.Image;
            return View(order);
        }

        public IActionResult AddToOrder(Order order)
        {
            return RedirectToAction("Menu");
        }
    }
}
