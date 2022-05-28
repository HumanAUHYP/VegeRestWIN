using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoreLibrary
{
    public static class ClientStorage
    {
        public static List<Client> Clients = new List<Client>();

        public static void Add(Client client)
        {
            if (Clients.Count != 0)
                client.Id = Clients.Last().Id + 1;
            else client.Id = 1;
            Clients.Add(client);
        }
        public static Client FindById(int id)
        {
            return Clients.Find(x => x.Id == id);
        }
        public static Client FindByTableNum(string tableNum)
        {
            return Clients.Find(x => x.TableNum == tableNum);
        }
    }
}
