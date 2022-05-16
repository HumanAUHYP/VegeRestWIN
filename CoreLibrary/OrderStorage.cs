using System;
using System.Collections.Generic;
using System.IO;

namespace CoreLibrary
{
    public class OrderStorage
    {
        public List<Order> Orders { get; private set; }

        public OrderStorage()
        {
            Orders = new List<Order>();
        }

        public void Add(Order order)
        {
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
                foreach (var el in Orders)
                {
                    sw.WriteLine(el);
                }
            }
        }
    }
}
