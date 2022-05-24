using System;
namespace CoreLibrary
{
    public class Order
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int ClientId { get; set; }
        public int CookingOptionId { get; set; }
        public int CuttingOptionId { get; set; }
        public int Count { get; set; }

        public Order() { }
        public Order(string str) 
        {
            var data = str.Split(';');
            Id = int.Parse(data[0]);
            MenuId = int.Parse(data[1]);
            ClientId = int.Parse(data[2]);
            CookingOptionId = int.Parse(data[3]);
            Count = int.Parse(data[4]);
        }
        public override string ToString()
        {
            return $"{Id};{MenuId};{ClientId};{CookingOptionId};{Count}";
        }
    }
}
