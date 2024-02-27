using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    internal class MainUI
    {
        public static string MainMenu()
        {
            Console.WriteLine("------WELCOME TO THE COFFEE SHOPS MANAGEMENT SYSTEM--------");
            Console.WriteLine();
            Console.WriteLine("1. ADD A MENU ITEM");
            Console.WriteLine("2. ADD A COFFEE SHOP");
            Console.WriteLine("3. VIEW THE CHEAPEST ITEM IN THE MENU FROM A SPECIFIC SHOP");
            Console.WriteLine("4. VIEW THE DRINK'S MENU FROM A SPECIFIC COFFEE SHOP");
            Console.WriteLine("5. VIEW THE FOOD'S MENU FROM A SPECIFIC COFFEE SHOP");
            Console.WriteLine("6. ADD ORDER IN A SPECIFIC COFFEE SHOP");
            Console.WriteLine("7. FULFILL THE ORDER IN A SPECIFIC COFFEE SHOP");
            Console.WriteLine("8. VIEW THE ORDER'S LIST FROM A SPECIFIC COFFEE SHOP");
            Console.WriteLine("9. TOTAL PAYABLE AMOUNT FROM A SPECIFIC COFFEE SHOP");
            Console.WriteLine("10. EXIT");
            Console.WriteLine();
            Console.Write("ENTER YOUR CHOICE: ");
            string Choice = Console.ReadLine();
            return Choice;
        }
    }
}
