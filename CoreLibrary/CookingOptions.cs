using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary
{
    class CookingOptions
    {
        public List<Option> Options { get; private set; }

        public CookingOptions()
        {
            Options = new List<Option>();
            Options.Add(new Option("1;Сварить;0"));
            Options.Add(new Option("2;Пожарить;0"));
            Options.Add(new Option("3;Не готовить;0"));
        }
    }
}
