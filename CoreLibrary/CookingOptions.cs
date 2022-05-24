using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary
{
    public static class CookingOptions
    {
        public static List<Option> Options { get; private set; }

        static CookingOptions()
        {
            Options = new List<Option>();
            Options.Add(new Option("1;Не готовить;0"));
            Options.Add(new Option("2;Сварить;0"));
            Options.Add(new Option("3;Пожарить;0"));
        }
    }
}
