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
