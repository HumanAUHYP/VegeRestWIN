using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLibrary;
using System.Collections.Generic;

namespace VegeRestTests
{
    [TestClass]
    public class MenuTest
    {
        [TestMethod]
        public void MenuConstructorTest()
        {
            Menu expectedMenu = new Menu
            {
                Id = 1,
                Name = "menu",
                Description = "descrip",
                Image = "img",
                Price = 2
            };

            Menu actualMenu = new Menu("1;menu;descrip;img;2");

            Assert.AreEqual(expectedMenu.ToString(), actualMenu.ToString());
        }

        [TestMethod]
        public void MenuStorageAddTest()
        {
            var menuStorage = new MenuStorage();

            var menu1 = new Menu("1;menu1;descrip;img;2");
            var menu2 = new Menu("2;menu2;descrip;img;2");
            var menu3 = new Menu("3;menu3;descrip;img;2");

            var listMenu = new List<Menu>{menu1, menu2, menu3};

            menuStorage.Add(menu1);
            menuStorage.Add(menu2);
            menuStorage.Add(menu3);

            CollectionAssert.AreEqual(menuStorage.Menues, listMenu);
        }

        [TestMethod]
        public void MenuStorageRemoveTest()
        {
            var menuStorage = new MenuStorage();

            var menu1 = new Menu("1;menu1;descrip;img;2");
            var menu2 = new Menu("2;menu2;descrip;img;2");
            var menu3 = new Menu("3;menu3;descrip;img;2");

            var listMenu = new List<Menu> { menu1, menu2 };

            menuStorage.Add(menu1);
            menuStorage.Add(menu2);
            menuStorage.Add(menu3);

            menuStorage.RemoveById("3");

            CollectionAssert.AreEqual(menuStorage.Menues, listMenu);
        }

        [TestMethod]
        public void MenuStorageChangeTest()
        {
            var menuStorage = new MenuStorage();

            var menu1 = new Menu("1;menu1;descrip;img;2");
            var menu2 = new Menu("2;menu2;descrip;img;2");
            
            menuStorage.Add(menu1);
            menuStorage.Add(menu2);

            menu2.Price = 10;
            menu2.Name = "changedMenu2";
            menu2.Description = "changedDescrip";
            menu2.Image = "changedImg";

            var listMenu = new List<Menu> { menu1, menu2 };

            menuStorage.Change(menu2);

            CollectionAssert.AreEqual(menuStorage.Menues, listMenu);
        }

        [TestMethod]
        public void MenuStorageWorkWithFileTest()
        {
            var path = "test.txt";

            var menuStorage = new MenuStorage();

            var menu1 = new Menu("1;menu1;descrip;img;2");

            menuStorage.Add(menu1);

            menuStorage.WriteInFile(path);
            menuStorage.Menues.Clear();
            menuStorage.ReadFromFile(path);

            Assert.AreEqual(menuStorage.Menues[0].ToString(), menu1.ToString());
        }
    }
}
