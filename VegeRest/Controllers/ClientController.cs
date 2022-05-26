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
        ClientStorage clientStorage;

        public ClientController(IWebHostEnvironment _environment, IMenuStorage _menuStorage, IClientStorage _clientStorage)
        {
            menuStorage = (MenuStorage)_menuStorage;
            clientStorage = (ClientStorage)_clientStorage;
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
            clientStorage.Add(client);
            return RedirectToAction("Menu");
        }

        public IActionResult Options(string id)
        {
            return View(menuStorage.FindById(id));
        }

        public IActionResult AddToOrder()
        {
            return View();
        }
    }
}
