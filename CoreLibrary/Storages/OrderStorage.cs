using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoreLibrary
{
    public interface IOrderStorage
    {
        void Add(Order order);
        void RemoveById(string id);
        void ReadFromFile(string path)
        void WriteInFile(string path);
    }
    public class OrderStorage : IOrderStorage
    {
        public List<Order> Orders { get; private set; }

        public OrderStorage()
        {
            Orders = new List<Order>();
        }

        public void Add(Order order)
        {
            if (Orders.Count != 0)
                order.Id = Orders.Last().Id + 1;
            else order.Id = 1;
            order.Price *= order.Count;
            Orders.Add(order);
        }

        public void RemoveById(string id)
        {
            Orders.RemoveAll(p => p.Id == int.Parse(id));
        }
        public void ReadFromFile(string path)
        {
            Orders.Clear();
            try
            {
                using (var sr = new StreamReader(path))
                {
                    string str;
                    while ((str = sr.ReadLine()) != null)
                    {
                        Orders.Add(new Order(str));
                    }
                }
            }
            catch (Exception) { }
        }
        public void WriteInFile(string path)
        {
            using (var sw = new StreamWriter(path, false))
            {
                foreach (var order in Orders)
                {
                    sw.WriteLine(order);
                }
            }
        }
    }
}
