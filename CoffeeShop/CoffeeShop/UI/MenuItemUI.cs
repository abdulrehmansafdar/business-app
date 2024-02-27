using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeShop
{
    internal class MenuItemUI
    {
        public static MenuItemBL TakeInputForItem()
        {
            Console.Write("Enter the Name of the Item: ");
            string Name = Console.ReadLine();
            Console.Write("Enter the Type of the Item (Food or Drink): ");
            string Type = Console.ReadLine();
            Console.Write("Enter the Price of the Item: Rs");
            float Price = float.Parse(Console.ReadLine());

            MenuItemBL  i = new MenuItemBL(Name, Type, Price);
            return i;

        }

        public static void DisplayAllItems()
        {
            Console.WriteLine("Items:");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("| Name         | Type         | Price |");
            Console.WriteLine("--------------------------------------");

            foreach (MenuItemBL item in MenuItemDL.MenuItems)
            {
                Console.WriteLine($"| {item.Name,-13} | {item.Type,-13} | {item.Price,5:F2} |");
            }

            Console.WriteLine("--------------------------------------");
        }

        public static int TakeNumberToAdd()
        {
            Console.Write("Enter the Numbers of Items to Add: ");
            int Number = int.Parse(Console.ReadLine());
            return Number;
        }

        public static string TakeName()
        {
            Console.Write("Enter the Name of The Item: ");
            string Name = Console.ReadLine() ;
            return Name;
        }

        public static void AddedSuccess()
        {
            Console.WriteLine("Item added Sucessfully!");
            Thread.Sleep(300);
        }

        public static void AlreadyExist()
        {
            Console.WriteLine("Items already Exist..");
            Thread.Sleep(300);
        }

        public static void  CouldntFint()
        {
            Console.WriteLine("Item doesn't exist");
            Thread.Sleep(300);
        }
        
    }
}
