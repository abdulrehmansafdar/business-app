using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    internal class MenuItemBL
    {
       public string Name;
       public string Type;
       public float Price;

        public MenuItemBL(string Name, string Type, float Price)
        {
            this.Name = Name;
            this.Type = Type;
            this.Price = Price;
        }
    }
}
