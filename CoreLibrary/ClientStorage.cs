using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoreLibrary
{
    public interface IClientStorage
    {
        void Add(Client client);
        void RemoveByTableNum(string tableNum);
    }
    public class ClientStorage : IClientStorage
    {
        
        public List<Client> Clients { get; private set; }

        public ClientStorage()
        {
            Clients = new List<Client>();
        }

        public void Add(Client client)
        {
            Clients.Add(client);
        }

        public void RemoveByTableNum(string tableNum)
        {
            Clients.RemoveAll(m => m.TableNum == tableNum);
        }
    }
}
