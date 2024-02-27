using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoffeeShop
{
    internal class CoffeShopDL
    {
        public static List <CoffeeShopBL> CoffeeShops = new List <CoffeeShopBL> ();

        public static void AddCoffeeShop(CoffeeShopBL c)
        {
            CoffeeShops.Add (c);    
        }

        public static CoffeeShopBL FindShop(string Name)
        {
            foreach(CoffeeShopBL stored in CoffeeShops)
            {
                if(Name == stored.NameOfShop)
                {
                    return stored;
                }
            }
            return null;
        }

        public static void StoreShops(string Path, CoffeeShopBL c)
        {
            StreamWriter f = new StreamWriter(Path, true);
            string Menu = "";
            for (int x = 0; x < c.Menu.Count - 1; x++)
            {
                Menu = Menu + c.Menu[x].Name + ";";
            }
            Menu = Menu + c.Menu[c.Menu.Count - 1].Name;
            f.WriteLine(c.NameOfShop + "," + Menu);
            f.Flush();
            f.Close();

        }

        public static bool ReadCoffeShops(string Path)
        {
            StreamReader f = new StreamReader(Path);
            string record;
            if (File.Exists(Path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string Name = splittedRecord[0];
                    string[] splittedRecordForMenu = splittedRecord[1].Split(';');
                    CoffeeShopBL c = new CoffeeShopBL(Name);
                    for (int x = 0; x < splittedRecordForMenu.Length; x++)
                    {
                        MenuItemBL m = MenuItemDL.FindItem(splittedRecordForMenu[x]);
                        if (m != null)
                        {
                            c.AddItem(m);
                        }
                    }
                    AddCoffeeShop(c);
                }
                f.Close();
                return true;
            }
            else
                return false;
        }
    }
}
