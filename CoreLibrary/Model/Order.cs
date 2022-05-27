﻿using System;
namespace CoreLibrary
{
    public class Order
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int ClientId { get; set; }
        public string CookingOption { get; set; }
        public string CuttingOption { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }

        public Order() { }
        public Order(string id, Menu menu)
        {
            MenuId = int.Parse(id);
            Image = menu.Image;
            Name = menu.Name;
            Price = menu.Price;
        }
        public Order(string str) 
        {
            var data = str.Split(';');
            Id = int.Parse(data[0]);
            MenuId = int.Parse(data[1]);
            ClientId = int.Parse(data[2]);
            CookingOption = data[3];
            CuttingOption = data[4];
            Count = int.Parse(data[5]);
        }
        public override string ToString()
        {
            return $"{Id};{MenuId};{ClientId};{CookingOption};{CuttingOption};{Count}";
        }
    }
}
