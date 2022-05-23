using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary
{
    public class CookingOption
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public CookingOption(string str)
        {
            var data = str.Split(';');
            Id = int.Parse(data[0]);
            Title = data[1];
        }
    }
}
