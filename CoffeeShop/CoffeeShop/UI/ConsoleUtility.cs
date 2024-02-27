using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.UI
{
    internal class ConsoleUtility
    {
        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void ReturnForAll() //this is used as a return function for all functions
        {
            Console.Write("Press any key to return...");
            Console.Read();
        }
    }
}
