using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signl_ogin
{
    internal class ownerUI
    {
       public static string Owner()
        {
            string opc;
            int cursorTop = Math.Min(Console.WindowTop + 5, Console.BufferHeight - 1);

            Console.SetCursorPosition(10, cursorTop);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@" 
       .--=   =--.
      /    \./    \
     (__|   :   |__)
        |   :   |
        |   :   |
        |___:___|");
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("                      //**********************\\");
            Console.WriteLine("                            Owner Menu");
            Console.WriteLine("                      //**********************\\");
            Console.WriteLine("-----------------------------------------------------------------------------------\n");
            Console.WriteLine("|\t\t\t1.\t Add Product...    \t\t\t\t|");
            Console.WriteLine("|\t\t\t2.\t Change price...   \t\t\t\t|");
            Console.WriteLine("|\t\t\t3.\t View stock...     \t\t\t\t|");
            Console.WriteLine("|\t\t\t4.\t Give discount...  \t\t\t\t|");
            Console.WriteLine("|\t\t\t5.\t Exit Owner Menu...\t\t\t\t|\n");
            Console.WriteLine("====================================================================================\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\t\t\tEnter option: ");
            opc = Console.ReadLine();
            if (opc != "1" && opc != "2" && opc != "3" && opc != "4")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option.....");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }
            return opc;
        }
        public static void show_owner(List<ownerBL> owner_data)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n");
            Console.Write("\t=========================================================================== \n");
            Console.Write("                              WELCOME TO STOCK STORE \n                                            ");
            Console.Write("\t=========================================================================== \n");
            Console.WriteLine("\tYou currently have following products......\n ");
            Console.WriteLine("\t\tProduct".PadRight(25) + "Quantity".PadRight(25) + "Price");

            foreach (var owner_obj in owner_data)
            {
                Console.WriteLine($"\t\t{owner_obj.owner_product.PadRight(25)}{owner_obj.owner_quantity.ToString().PadRight(25)}{owner_obj.owner_price}");
            }
            Console.Write("Press any key to continue.....");
            Console.ReadKey();
        }

        public static ownerBL add_product_for_owner( List<ownerBL> owner_data)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n");
            Console.Write("\t=========================================================================== \n");
            Console.Write("                              PRODUCTS VARIETY \n                                            ");
            Console.Write("\t=========================================================================== \n");

            Console.Write("\t\t\t\t\t1.\tshirts\n\n");
            Console.Write("\t\t\t\t\t2.\tpants\n\n");
            Console.Write("\t\t\t\t\t3.\tties\n\n");
            Console.Write("\t\t\t\t\t4.\tcoats\n\n");
            Console.Write("\t\t\t\t\t5.\tcotton suits\n\n");
            Console.Write("\t\t\t\t\t6.\twashing wear suits\n\n");
            Console.Write("\t\t\t\t\t7.\tjackets\n\n");
            Console.Write("\t\t\t\t\t8.\twaist coats\n\n");
            Console.Write("\t\t\t\t\t9.\tsocks\n\n");
            Console.Write("\t\t\t\t\t10.\ttracksuits\n\n");
            Console.Write("\n\n");
            Console.WriteLine("\t\tWelcome to shopping menu");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("\t\t\tEnter the clothing item you want to add in your store: ");
            string productName = Console.ReadLine();

            // Check if the product already exists in owner_data
            ownerBL existingProduct = owner_data.Find(p => p.owner_product.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (existingProduct != null)
            {
                // Product already exists, ask for additional quantity
                Console.Write("\t\t\tProduct already exists. Enter additional quantity: ");
                string input = Console.ReadLine();
                int additionalQuantity = utility.errorhandles(input);
               
                existingProduct.owner_quantity += additionalQuantity;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Quantity updated for {existingProduct.owner_product}. Total quantity: {existingProduct.owner_quantity}");
            }
            else
            {
                // Product does not exist, ask for quantity and price
                Console.Write("\t\t\tEnter the quantity: ");
                string input1 = Console.ReadLine();
                int quantity = utility.errorhandles(input1);
                
                Console.Write("\t\t\tEnter the price: ");
                string input = Console.ReadLine();
                float price = utility.errorhandles(input);
               
                // Create a new ownerBL object
                ownerBL newProduct = new ownerBL(productName, quantity, price);

                // Return the new product to be added to the owner_data list
                return newProduct;
            }

            return null;


        }


        public static void ChangePriceForProduct(List<ownerBL> owner_data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the product for which you want to change the price: ");
            string productToChange = Console.ReadLine();

            // Find the product in the list
            ownerBL product = owner_data.Find(p => p.owner_product.Equals(productToChange, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                Console.WriteLine($"Current price for {product.owner_product}: {product.owner_price}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Enter the new price: ");
                string input = Console.ReadLine();
                float newPrice = utility.errorhandles(input);
                
                // Call the ChangePrice method
                product.ChangePrice(newPrice);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Product {productToChange} not found.");
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        public static void GiveDiscountForProduct(List<ownerBL> owner_data)
        {
            Console.WriteLine("Enter the product for which you want to give a discount: ");
            string productToDiscount = Console.ReadLine();

            // Find the product in the list
            ownerBL product = owner_data.Find(p => p.owner_product.Equals(productToDiscount, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                Console.WriteLine($"Current price for {product.owner_product}: {product.owner_price}");
                Console.Write("Enter the discount percentage: ");
                string input = Console.ReadLine();
                float discountPercentage = utility.errorhandles(input);
               
                // Call the GiveDiscount method
                product.GiveDiscount(discountPercentage);
            }

            else
            {
                Console.WriteLine($"Product {productToDiscount} not found.");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t...........Price updated succesfully......");
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
        }

       
    }
}
