using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary
{
    public class OptionStorage
    {
        public List<CookingOption> CookingOptions { get; private set; }

        public OptionStorage()
        {
            CookingOptions = new List<CookingOption>();
            CookingOptions.Add()
        }

        public void Add(CookingOption cookingOption)
        {
            CookingOptions.Add(cookingOption);
        }
    }
}
