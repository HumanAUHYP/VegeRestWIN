using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using CoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegeRest.Controllers
{
    public class PasekaController : Controller
    {
        private string path = @"..\CoreLibrary\data\menu.txt";

        // ссылка на объект - хранилище заказов
        MenuStorage menuStorage;

        public PasekaController(IWebHostEnvironment _environment, IMenuStorage _menuStorage)
        {
            menuStorage = (MenuStorage)_menuStorage;
        }
        public IActionResult Index()
        {
            menuStorage.ReadFromFile(path);
            var today = DateTime.Today;
            foreach (Menu menu in menuStorage.Menues)
            {
                menu.DaysForCheck -= (int)Math.Round((today - menu.AddDate).TotalDays);
                if (menu.DaysForCheck < 0)
                    menu.DaysForCheck = 0;
            }
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
