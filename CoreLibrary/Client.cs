using System;
namespace CoreLibrary
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TableNum { get; set; }
        public Client() { }
        public Client(string str)
        {
            var data = str.Split(';');
            Id = int.Parse(data[0]);
            Name = data[1];
            TableNum = data[2];
        }
    }
}
