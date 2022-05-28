using System;
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
            Name = data[1];
            ClientId = ClientStorage.FindByTableNum(data[2]).Id;
            CookingOption = data[3];
            CuttingOption = data[4];
            Count = int.Parse(data[5]);
        }
        public override string ToString()
        {
            return $"{Id};{Name};{ClientStorage.FindById(ClientId).TableNum};{CookingOption};{CuttingOption};{Count}";
        }
    }
}
