using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }


        public Menu() { }

        public Menu(string str)
        {
            var data = str.Split(';');
            Id = int.Parse(data[0]);
            Name = data[1];
            Description = data[2];
            Image = data[3];
            Price = double.Parse(data[4]);
        }

        public override string ToString()
        {
            return $"{Id};{Name};{Description};{Image};{Price}";
        }
    }
}
