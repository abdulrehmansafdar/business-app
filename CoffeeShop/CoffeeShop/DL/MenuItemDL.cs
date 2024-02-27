using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoffeeShop
{
    internal class MenuItemDL
    {
        public static List <MenuItemBL> MenuItems = new List<MenuItemBL>();

        public static void AddItemsInMenu(MenuItemBL i)
        {
            MenuItems.Add(i);
        }

        public static MenuItemBL FindItem(string Name)
        {
            foreach(MenuItemBL item in MenuItems)
            {
                if(Name == item.Name)
                {
                    return item;
                }
            }
            return null;
        }

        public static List<MenuItemBL> AddItemsforShop(int Number)
        {
            List<MenuItemBL> Items = new List<MenuItemBL>();
            for (int i = 0; i < Number; i++)
            {
                string Name = MenuItemUI.TakeName();
                if (MenuItemDL.FindItem(Name) != null)
                {
                    if (!(Items.Contains(MenuItemDL.FindItem(Name))))
                    {
                        Items.Add(MenuItemDL.FindItem(Name));
                        MenuItemUI.AddedSuccess();
                    }
                    else
                    {
                        MenuItemUI.AlreadyExist();
                    }

                }
                else
                {
                    MenuItemUI.CouldntFint();
                }

            }
            return Items;
        }

        public static void StoreItem(string Path, MenuItemBL m)
        {
            StreamWriter f = new StreamWriter(Path, true);
            f.WriteLine(m.Name + "," + m.Type + "," + m.Price);
            f.Flush();
            f.Close();
        }

        public static bool ReadItems(string Path)
        {
            StreamReader f = new StreamReader(Path);
            string record;
            if (File.Exists(Path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string Name = splittedRecord[0];
                    string Type = splittedRecord[1];
                    float Price = float.Parse(splittedRecord[2]);
                    MenuItemBL m = new MenuItemBL(Name, Type, Price);
                    AddItemsInMenu(m);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }





    }
}
