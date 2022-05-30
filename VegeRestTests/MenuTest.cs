using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLibrary;

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
            menuStorage.Add(menu1);
            menuStorage.Add(menu2);
            menuStorage.Add(menu3);


        }
    }
}
