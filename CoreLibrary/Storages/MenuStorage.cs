using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            if (Menues.Count != 0)
                menu.Id = Menues.Last().Id + 1;
            else menu.Id = 1;
            Menues.Add(menu);
        }

        public void Change(Menu menu)
        {
            Menu chMenu = Menues.Find(m => m.Id == menu.Id);
            chMenu.Name = menu.Name;
            chMenu.Description = menu.Description;
            chMenu.Image = menu.Image;
            chMenu.Price = menu.Price;
        }

        public void RemoveById(string id)
        {
            Menues.RemoveAll(m => m.Id == int.Parse(id));
        }

        public Menu FindById(string id)
        {
            return Menues.Find(m => m.Id == int.Parse(id));
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
                foreach (var menu in Menues)
                {
                    sw.WriteLine(menu);
                }
            }
        }
    }
}
