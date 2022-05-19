using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using CoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegeRest.Controllers
{
    public class ManagerController : Controller
    {
        private IWebHostEnvironment Environment;
        private string path = @"C:\Users\Human\source\repos\VegeRest\CoreLibrary\data\orders.txt";

        // ссылка на объект - хранилище заказов
        MenuStorage menuStorage;

        public ManagerController(IWebHostEnvironment _environment, IMenuStorage _menuStorage)
        {
            menuStorage = (MenuStorage)_menuStorage;
        }
        public IActionResult Index()
        {
            menuStorage.ReadFromFile(path);
            var menues = menuStorage.Menues;
            
            return View(menues);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Menu menu)
        {
            menuStorage.Add(menu);
            menuStorage.WriteInFile(path);
            return RedirectToAction("Index");
        }

        public IActionResult Change(string id)
        {
            return View(menuStorage.FindById(id));
        }

        [HttpPost]
        public IActionResult Change(Menu menu)
        {
            menuStorage.Change(menu);
            menuStorage.WriteInFile(path);
            return RedirectToAction("Index");
        }
        public IActionResult Remove(string id)
        {
            menuStorage.RemoveById(id);
            menuStorage.WriteInFile(path);
            return RedirectToAction("Index");
        }
    }
}
