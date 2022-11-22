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
            menu.CheckQuinCells = false;
            menu.IsCull = false;
            menu.CheckBeehive = false;
            menu.DaysForCheck = CountDaysForCheck(menu).DaysForCheck;
            menu.AddDate = DateTime.Today;
            Menues.Add(menu);
        }

        public void Change(Menu menu)
        {
            Menu chMenu = Menues.Find(m => m.Id == menu.Id);
            if (chMenu.CheckQuinCells != menu.CheckQuinCells ||
                chMenu.IsCull != menu.IsCull ||
                chMenu.CheckBeehive != menu.CheckBeehive)
                chMenu.AddDate = DateTime.Today;
            chMenu.Name = menu.Name;
            chMenu.Description = menu.Description;
            chMenu.Image = menu.Image;
            chMenu.FiledFrames = menu.FiledFrames;
            chMenu.CheckQuinCells = menu.CheckQuinCells;
            chMenu.IsCull = menu.IsCull;
            chMenu.CheckBeehive = menu.CheckBeehive;
            chMenu.DaysForCheck = CountDaysForCheck(chMenu).DaysForCheck;
        }

        public Menu CountDaysForCheck(Menu menu)
        {
            if (menu.IsLayering)
                menu.DaysForCheck = 4;
            if (menu.CheckQuinCells)
                menu.DaysForCheck = 1;
            if (menu.IsCull)
                menu.DaysForCheck = 1;
            if (menu.CheckBeehive)
                menu.DaysForCheck = 16;
            return menu;
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
