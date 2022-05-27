using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoreLibrary
{
    public static class ClientStorage
    {
        
        public static List<Client> Clients = new List<Client>();

        public static void Add(Client client)
        {
            Clients.Add(client);
        }

        public static void RemoveByTableNum(string tableNum)
        {
            Clients.RemoveAll(m => m.TableNum == tableNum);
        }
    }
}
