using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoreLibrary;
using System.Collections.Generic;

namespace VegeRestTests
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void OrderConstructorTest()
        {
            ClientStorage.Add(new Client("1;client;10"));
            var expectedOrder = new Order
            {
                Id = 1,
                Name = "order",
                ClientId = 1,
                CookingOption = CookingOptions.Options[0].Title,
                CuttingOption = CuttingOptions.Options[0].Title,
                Count = 5
            };

            Order actualOrder = new Order("1;order;10;Не готовить;Не нарезать;5");

            Assert.AreEqual(expectedOrder.ToString(), actualOrder.ToString());
        }

        [TestMethod]
        public void OrderStorageAddTest()
        {
            ClientStorage.Add(new Client("1;client;10"));
            var orderStorage = new OrderStorage();

            var order1 = new Order("1;order1;10;Не готовить;Не нарезать;5");
            var order2 = new Order("2;order2;10;Не готовить;Не нарезать;5");
            var order3 = new Order("3;order3;10;Не готовить;Не нарезать;5");
            

            var listOrder = new List<Order> { order1, order2, order3 };

            orderStorage.Add(order1);
            orderStorage.Add(order2);
            orderStorage.Add(order3);

            CollectionAssert.AreEqual(orderStorage.Orders, listOrder);
        }

        [TestMethod]
        public void OrderStorageRemoveTest()
        {
            var orderStorage = new OrderStorage();

            var order1 = new Order("1;order1;10;Не готовить;Не нарезать;5");
            var order2 = new Order("2;order2;10;Не готовить;Не нарезать;5");
            var order3 = new Order("3;order3;10;Не готовить;Не нарезать;5");

            var listOrder = new List<Order> { order1, order2 };

            orderStorage.Add(order1);
            orderStorage.Add(order2);
            orderStorage.Add(order3);

            orderStorage.RemoveById("3");

            CollectionAssert.AreEqual(orderStorage.Orders, listOrder);
        }

        [TestMethod]
        public void OrderStorageChangeTest()
        {
            var orderStorage = new OrderStorage();

            var order1 = new Order("1;order1;10;Не готовить;Не нарезать;5");
            var order2 = new Order("2;order2;10;Не готовить;Не нарезать;5");

            orderStorage.Add(order1);
            orderStorage.Add(order2);

            order2.Price = 10;
            order2.Name = "changedOrder2";
            order2.CookingOption = "changedCookingOption";
            order2.CuttingOption = "changedCuttingOption";
            order2.Count = 8;

            var listOrder = new List<Order> { order1, order2 };

            orderStorage.Change(order2);

            CollectionAssert.AreEqual(orderStorage.Orders, listOrder);
        }

        [TestMethod]
        public void OrderStorageWorkWithFileTest()
        {
            var path = "test.txt";

            var orderStorage = new OrderStorage();

            var order1 = new Order("1;order1;10;Не готовить;Не нарезать;5");

            orderStorage.Add(order1);

            orderStorage.WriteInFile(path);
            orderStorage.Orders.Clear();
            orderStorage.ReadFromFile(path);

            Assert.AreEqual(orderStorage.Orders[0].ToString(), order1.ToString());
        }
    }
}
