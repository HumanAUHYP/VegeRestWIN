using System.Collections.Generic;

namespace CoreLibrary
{
    public static class CuttingOptions
    {
        public static List<Option> Options { get; private set; }

        static CuttingOptions()
        {
            Options = new List<Option>();
            Options.Add(new Option("1;Не нарезать;0"));
            Options.Add(new Option("2;Полосками;0"));
            Options.Add(new Option("3;На терке;0"));
            Options.Add(new Option("4;Кубиками;0"));
        }
    }
}
