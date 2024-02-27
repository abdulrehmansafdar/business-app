using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeShop.UI
{
    internal class CoffeeShopUI
    {
        public static void ItemUnavailable()
        {
            Console.WriteLine("This item is currently unavailable!");
            Thread.Sleep(300);
        }
        public static  CoffeeShopBL TakeDetails()
        {
            Console.Write("Enter the Name of The Coffee Shop: ");
            string Name = Console.ReadLine();
            int Number = MenuItemUI.TakeNumberToAdd();
            List<MenuItemBL> Items = MenuItemDL.AddItemsforShop(Number);

            CoffeeShopBL c = new CoffeeShopBL(Name, Items);

            return c;

        }

        public static string TakeNameOfShop()
        {
            Console.Write("Enter the name of the Coffee Shop: ");
            string Name = Console.ReadLine();
            return Name;
        }

        public static void PrintCheapest(CoffeeShopBL c)
        {
            Console.WriteLine("The Cheapest Item in the Coffee Shop " + c.NameOfShop + " is : " + c.CheapestItem());
        }

        public static void PrintShopNotFound()
        {
            Console.WriteLine("The Shop is Not Found...");
            Thread.Sleep(300);

        }

        public static void DisplayDrinks(List<string> Drinks)
        {
            Console.WriteLine("List of Drinks:");
            foreach (var drink in Drinks)
            {
                Console.WriteLine(drink);
            }
        }

        public static void DisplayFoods(List<string> Foods)
        {
            Console.WriteLine("List of Foods:");
            foreach (var food in Foods)
            {
                Console.WriteLine(food);
            }
        }

        public static void DisplayOrders(List <string> Orders)
        {
            Console.WriteLine("List of Orders:");
            foreach (var food in Orders)
            {
                Console.WriteLine(food);
            }
        }

        public static void DisplayMenu(CoffeeShopBL c)
        {
            Console.WriteLine("Items:");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("| Name         | Type         | Price |");
            Console.WriteLine("--------------------------------------");

            foreach (MenuItemBL item in c.Menu)
            {
                Console.WriteLine($"| {item.Name,-13} | {item.Type,-13} | {item.Price,5:F2} |");
            }

            Console.WriteLine("--------------------------------------");
        }

        public static void ClearOrders(CoffeeShopBL c)
        {
            while (c.Orders.Count < 0)
            {
                Console.WriteLine(c.FulfillOrder());
            }
        }

        public static void PrintTotal(CoffeeShopBL c)
        {
            Console.WriteLine("The total Payable Amount of " + c.NameOfShop + " is: Rs" + c.DueAmount());
        }

        public static string TakeNameOfItem()
        {
            Console.Write("Enter the Name of the Item: ");
            return Console.ReadLine();
        }

        public static void ItemAdded()
        {
            Console.WriteLine("The item is added...");
        }
    }
}
