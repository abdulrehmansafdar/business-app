using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signl_ogin
{
    internal class customerUI
    {
        public static string Customer()
        {
            string opc;
           

            Console.SetCursorPosition(10, 20);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@" 
         __   __
       /|  `-´  |\
      /_|  o.o  |_\
        | o`o´o |
        |  o^o  |
        |_______|");
            Console.SetCursorPosition(20, 10);

           

            Console.SetCursorPosition(10, 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("                      //**********************\\");
            Console.WriteLine("                            CUSTOMER Menu");
            Console.WriteLine("                      //**********************\\");
            Console.WriteLine("-----------------------------------------------------------------------------------\n");
            Console.WriteLine("|\t\t\t1.\t Add to Cart...    \t\t\t\t|");
            Console.WriteLine("|\t\t\t2.\t Buy from Cart...   \t\t\t\t|");
            Console.WriteLine("|\t\t\t3.\t View Bill...     \t\t\t\t|");
            Console.WriteLine("|\t\t\t4.\t ...  \t\t\t\t|");
            Console.WriteLine("|\t\t\t5.\t Exit Customer Menu...\t\t\t\t|\n");
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
       public static void show_customer(List<ownerBL> owner_data, List<customerBL> customer_bdata)
        {
            float total = 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n");
            Console.Write("\t=========================================================================== \n");
            Console.Write("                              YOUR BILL \n");
            Console.Write("\t=========================================================================== \n");
            Console.WriteLine("\tYou currently have following products......\n ");
            Console.WriteLine("\t\tProduct".PadRight(25) + "Quantity".PadRight(25) + "Size");

            foreach (var owner_obj in customer_bdata)
            {
                Console.WriteLine($"\t\t{owner_obj.customer_product.PadRight(25)}{owner_obj.customer_quantity.ToString().PadRight(25)}{owner_obj.customer_size}");
            }

            // Create a customer object and calculate the total bill
            customerBL obj = new customerBL();
            total = obj.total_bill(owner_data, customer_bdata);

            Console.WriteLine();
            Console.WriteLine("\t\t---------------------------------------");
            Console.WriteLine("\t\tTotal bill is..... |  " + total + ".00_/RS  |");
            Console.WriteLine("\t\t---------------------------------------");


            DateTime now = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Date...//..Time");
            Console.WriteLine(now);

            Console.Write("Press any key to continue.....");
            Console.ReadKey();
        }

        public static customerBL add_to_cart(List<customerBL> customer_cdata, List<ownerBL> owner_data)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("\t Following products are available......\n ");
            Console.WriteLine("\t\tProduct".PadRight(25) + "Quantity".PadRight(25) + "Price");

            foreach (var owner_obj in owner_data)
            {
                Console.WriteLine($"\t\t{owner_obj.owner_product.PadRight(25)}{owner_obj.owner_quantity.ToString().PadRight(25)}{owner_obj.owner_price}");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n");
            Console.Write("\t\tEnter product's name: ");
            string name = Console.ReadLine();

            // Check if the product exists in the owner_data list
            ownerBL product = customerBL.isProductInOwner(customer_cdata,owner_data,name);

            if (product != null)
            {
                Console.WriteLine($"\tAvailable quantity for {product.owner_product}: {product.owner_quantity}\n");
                Console.Write("\t\tEnter the quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                utility.errorhandles(quantity);

                // Check if the entered quantity is less than or equal to the available quantity
                if (quantity > 0 && quantity <= product.owner_quantity)
                {
                    Console.Write("\t\tEnter the size: ");
                    string size = Console.ReadLine();

                    // Check if the customer has already purchased the same product with the same size
                    customerBL existingItem = customerBL.isProductAlreadyFound(customer_cdata, name,size);
                    if (existingItem != null)
                    {
                        Console.Write($"\tYou have already purchased {existingItem.customer_quantity} {existingItem.customer_size} of {existingItem.customer_product}. Enter additional quantity: ");
                        int additionalQuantity = int.Parse(Console.ReadLine());
                        utility.errorhandles(additionalQuantity);
                        existingItem.customer_quantity += additionalQuantity;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\tQuantity updated for {existingItem.customer_product}. Total quantity: {existingItem.customer_quantity}\n");

                    }
                    else
                    {
                        product.owner_quantity -= quantity;

                        customerBL cust_obj = new customerBL(name, quantity, size);
                       
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tProduct added successfully to cart.\n");
                        return cust_obj;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tInvalid quantity. Please enter a valid quantity within the available stock.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tProduct not found. Please check the product name.");
                return null;
            }
            return null;
        }

        public static customerBL buy_customer(List<customerBL> customer_cdata, List<customerBL> customer_bdata)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("\t Following products are available for purchase...\n ");
            Console.WriteLine("\t\tProduct".PadRight(25) + "Quantity".PadRight(25) + "Size");

            foreach (var customer_obj in customer_cdata)
            {
                Console.WriteLine($"\t\t{customer_obj.customer_product.PadRight(25)}{customer_obj.customer_quantity.ToString().PadRight(25)}{customer_obj.customer_size}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n");
            Console.Write("\t\tEnter product's name: ");
            string name = Console.ReadLine();

            // Check if the product exists in the customer_cdata list
            customerBL product = customerBL.isProductInCart(customer_cdata,name);

            if (product != null)
            {
                Console.WriteLine($"\t\tAvailable quantity for {product.customer_product}: {product.customer_quantity}\n");
                Console.Write("\t\tEnter the quantity to purchase: ");
                int purchaseQuantity = int.Parse(Console.ReadLine());
                utility.errorhandles(purchaseQuantity);

                // Check if the entered quantity is less than or equal to the available quantity
                if (purchaseQuantity > 0 && purchaseQuantity <= product.customer_quantity)
                {
                    Console.Write("\t\tEnter the size: ");
                    string size = Console.ReadLine();

                    // Reduce the available quantity in the customer_cdata list
                    product.customer_quantity -= purchaseQuantity;

                    // Add the purchased product to the customer_bdata list
                    customerBL cusb = new customerBL(name, purchaseQuantity, size);


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\tProduct purchased successfully.\n");
                    return cusb;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tInvalid quantity. Please enter a valid quantity within the available stock.\n");
                    return null;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tProduct not found. Please check the product name.\n");
                return null;
            }

        }

    }
}
