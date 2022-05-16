using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public interface IMenuStorage
    {
        void Add(Menu menu);
        void RemoveById(string id);
        void ReadFromFile(string path);
        void WriteInFile(string path);
    }
    public class MenuStorage : IMenuStorage
    {
        public List<Menu> Menues { get; private set; }

        public MenuStorage()
        {
            Menues = new List<Menu>();
        }

        public void Add(Menu menu)
        {
            Menues.Add(menu);
        }

        public void RemoveById(string id)
        {
            Menues.RemoveAll(p => p.Id == int.Parse(id));
        }

        public void ReadFromFile(string path)
        {
            Menues.Clear();
            try
            {
                using (var sr = new StreamReader(path))
                {
                    string str;
                    while ((str = sr.ReadLine()) != null)
                    {
                        Menues.Add(new Menu(str));
                    }
                }
            }
            catch (Exception) { }
        }

        public void WriteInFile(string path)
        {
            using (var sw = new StreamWriter(path, false))
            {
                foreach (var el in Menues)
                {
                    sw.WriteLine(el);
                }
            }
        }
    }
}
