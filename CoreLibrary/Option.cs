using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary
{
    class Option
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Option() { }
        public Option(string str)
        {
            var data = str.Split(';');
            Id = int.Parse(data[0]);
            Title = data[1];
            Price = double.Parse(data[1]);
        }
    }
}
