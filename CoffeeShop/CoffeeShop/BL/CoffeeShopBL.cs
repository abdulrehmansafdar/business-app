using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop    
{
    internal class CoffeeShopBL
    {
        public string NameOfShop;
        public List <MenuItemBL> Menu = new List <MenuItemBL> ();
        public List <string> Orders = new List <string> ();

        public CoffeeShopBL(string nameOfShop, List<MenuItemBL> menu)
        {
            NameOfShop = nameOfShop;
            Menu = menu;
        }
        public CoffeeShopBL(string Name)
        {
            NameOfShop = Name;
        }

        public void AddItem(MenuItemBL i)
        {
            Menu.Add(i);
        }

        public bool AddOrder(string Name)
        {
            foreach (MenuItemBL i in Menu)
            {
                if (Name == i.Name)
                {
                    Orders.Add (Name);
                    return true;
                }
                
            }

            return false;
            
        }

        public string FulfillOrder()
        {
            if (Orders.Count > 0)
            {
                string item = Orders[0];
                Orders.RemoveAt(0); // Empty the list
                return $"The {item} is ready!";
            }
            else
            {
                return "All orders have been fulfilled!";
            }
        }

        public  List<string> ListOrders()
        {
            if (Orders.Count > 0)
            {
                return Orders;
            }
            else
            {
                return null;
            }
        }

        public float DueAmount()
        {
            float TotalAmount = 0; 
            for(int i=0;  i<Orders.Count; i++)
            {
                foreach(MenuItemBL stored in Menu)
                {
                    if (Orders[i] == stored.Name)
                    {
                        TotalAmount += stored.Price;
                    }
                }
            }

            return TotalAmount;
        }

        public string CheapestItem()
        {
            float MinPrice = float.MaxValue;
            string Cheapest = "";

            foreach(MenuItemBL stored in Menu)
            {
                if(stored.Price < MinPrice)
                {
                    MinPrice = stored.Price;
                    Cheapest = stored.Name;
                }
            }


            return Cheapest;
        }

        public List<string> GetDrinks()
        {
            List<string> Drinks = new List<string>();

            foreach(MenuItemBL item in Menu)
            {
                if(item.Type=="Drink")
                {
                    Drinks.Add(item.Name);
                }
            }

            return Drinks;
        }

        public List<string> GetFoods()
        {
            List<string> Foods = new List<string>();

            foreach (MenuItemBL item in Menu)
            {
                if (item.Type == "Food")
                {
                    Foods.Add(item.Name);
                }
            }

            return Foods;
        }

        public static bool IsShop(CoffeeShopBL c)
        {
            if(c!=null)
            {
                return true;
            }
            return false;
        }




    }
}
