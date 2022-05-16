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
        private string path = @"C:\Users\Human\source\repos\VegeRest\CoreLibrary\data\orders.txt";

        // ссылка на объект - хранилище заказов
        MenuStorage menuStorage;

        public ClientController(IWebHostEnvironment _environment, IMenuStorage _menuStorage)
        {
            menuStorage = (MenuStorage)_menuStorage;
        }

        public IActionResult Index()
        {
            menuStorage.ReadFromFile(path);
            var menues = menuStorage.Menues;

            return View(menues);
        }
    }
}
