using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary
{
    class CuttingOptions
    {
        public List<Option> Options { get; private set; }

        public CuttingOptions()
        {
            Options = new List<Option>();
            Options.Add(new Option("1;Полосками;0"));
            Options.Add(new Option("2;На терке;0"));
            Options.Add(new Option("3;Кубиками;0"));
            Options.Add(new Option("3;Не нарезать;0"));
        }
    }
}
