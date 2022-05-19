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
        void ReadFromFile(string path);
        void WriteInFile(string path);
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

        public void ReadFromFile(string path)
        {
            Clients.Clear();
            try
            {
                using (var sr = new StreamReader(path))
                {
                    string str;
                    while ((str = sr.ReadLine()) != null)
                    {
                        Clients.Add(new Client(str));
                    }
                }
            }
            catch (Exception) { }
        }

        public void WriteInFile(string path)
        {
            using (var sw = new StreamWriter(path, false))
            {
                foreach (var client in Clients)
                {
                    sw.WriteLine(client);
                }
            }
        }
    }
}
