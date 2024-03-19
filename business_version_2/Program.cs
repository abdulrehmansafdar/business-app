
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using task01.DL;

namespace signl_ogin
{
    class Program
    {
        static void Main(string[] args)
        {
            //create list named login
            List<loginBL> users =loginDL.GetuserData();
            List<ownerBL> owner_data =ownerDL.GetOwnerData();  
            List<customerBL> customer_cdata = customerDL.Getcustomer1Data();
            List<customerBL> customer_bdata = customerDL.Getcustomer2Data();
           
            string opc;
            //filename
            string path = "textfile.txt";
            string path1 = "owner.txt";
            string op1;
            int option = 0;
            //function for reading data and show result on console
            bool check = loginDL.read_data(path, users);
            bool check2 = ownerDL.read_data1(path1, owner_data);

            if (check)
            {
                // if data is loaded
                Console.WriteLine("Data loaded...1");
            }
            if (check2)
            {
                // if data is loaded
                Console.WriteLine("Data loaded...2");
            }

            else
            {
                //if data is not loaded 
                Console.WriteLine("Data not loaded!");
            }
            Console.ReadKey();
            do
            {
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    //creating object of class'login' named user and assinged it function loginx which take input from user for login
                    loginBL user = loginUI.loginx();
                    loginDL.storedatainlist(user);
                    if (user != null)
                    {
                        //if object is not empty  assign it returning value of signin
                        user = loginUI.signin(user,users);


                    }
                    if (user == null)
                    {
                        Console.WriteLine("Invalid username or password. Account does not exist.");
                    }
                    else if (user.isOwner())
                    {
                        //if object satisfying condition for role as owner
                        Console.Clear();
                        do
                        {
                            Console.Clear();
                            opc = ownerUI.Owner();
                            if (opc == "1")
                            {
                                Console.Clear();
                                Console.WriteLine("Adding a new product for owner...");

                                // Call the UI method to get the new product details
                                ownerBL newProduct = ownerUI.add_product_for_owner(owner_data);

                                if (newProduct != null)
                                {
                                    // Call the data layer method to add the new product to the list
                                    ownerDL.AddProductToList(owner_data, newProduct);

                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine($"Product '{newProduct.owner_product}' added successfully!");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Failed to add the product.");
                                }
                                Console.WriteLine("Press any key to continue.....");
                                Console.ReadKey();

                            }
                            else if (opc == "2")
                            {
                                Console.Clear();
                                ownerUI.ChangePriceForProduct(owner_data);
                            }
                            else if (opc == "3")
                            {
                                Console.Clear();
                                ownerUI.show_owner(owner_data);
                            }
                            else if (opc == "4")
                            {
                                Console.Clear();
                                ownerUI.GiveDiscountForProduct(owner_data);
                            }
                            else if (opc == "5")
                            {
                                Console.WriteLine(@"
                    _______  _____ _____ _____ ___ _   _  ____ 
                    | ____\ \/ /_ _|_   _|_   _|_ _| \ | |/ ___|
                    |  _|  \  / | |  | |   | |  | ||  \| | |  _ 
                    | |___ /  \ | |  | |   | |  | || |\  | |_| |
                    |_____/_/\_\___| |_|   |_| |___|_| \_|\____|");
                                Thread.Sleep(500);
                                Console.Clear();
                            }

                        } while (opc == "1" || opc == "2" || opc == "3" || opc == "4" || opc == "5");
                        ownerDL.storedatainfile1(path1, owner_data);
                    }
                    else if (user.isCustomer())
                    {
                        Console.WriteLine("Customer Menu.");
                        Console.Clear();
                        do
                        {
                            Console.Clear();
                            op1 = customerUI.Customer();
                            if (op1 == "1")
                            {
                                Console.Clear();
                                customerBL cus = customerUI.add_to_cart(customer_cdata, owner_data);
                                customerDL.addcartlist(cus);
                                Console.WriteLine("Press any key to continue......");
                                Console.ReadKey();


                            }
                            else if (op1 == "2")
                            {
                                Console.Clear();
                                customerBL cus1 = customerUI.buy_customer(customer_cdata, customer_bdata);
                                customerDL.addbuylist(cus1);
                               Console.WriteLine("Press any key to continue......");
                                Console.ReadKey();

                            }
                            else if (op1 == "3")
                            {
                                Console.Clear();
                                customerUI.show_customer(owner_data, customer_bdata);

                            }
                            else if (op1 == "4")
                            {
                                Console.Clear();

                            }
                            else if (op1 == "5")
                            {
                                Console.WriteLine(@"
                    _______  _____ _____ _____ ___ _   _  ____ 
                    | ____\ \/ /_ _|_   _|_   _|_ _| \ | |/ ___|
                    |  _|  \  / | |  | |   | |  | ||  \| | |  _ 
                    | |___ /  \ | |  | |   | |  | || |\  | |_| |
                    |_____/_/\_\___| |_|   |_| |___|_| \_|\____|");
                                Thread.Sleep(500);
                                Console.Clear();
                            }

                        } while (op1 == "1" || op1 == "2" || op1 == "3" || op1 == "4" || op1 == "5");
                    }
                }
                else if (option == 2)
                {
                    //now assign returning value of signinx to object named 'user'
                    loginBL user = loginUI.signinx(users);
                    if (user != null)
                    {
                        //if object is not null store it in the file and in the list declared above
                        loginDL.storedatainfile(path, user);

                        loginDL.storedatainlist( user);
                    }

                }
                Console.ReadKey();


            } while (option < 3 && option > 0);



        }
        static int menu()
        {
            int option;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(@"              
                #########################          
              #############################        
            #################################      
          #####################################    
         #######################################   
        ##################     ##################  
       ################           ################ 
      ################             ################
      ###############               ###############
      ###############               ###############
      ###############               ###############
      ################             ################
      ##################         ##################
      #############################################
      #############################################
        ############                   ############ 
         #########                       #########  
          #######                         #######   
           ######                         ######    
             #######                   #######      
               ########             ########        
                 #########################          
                              ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                        WELCOME to main Menu                ");
            Console.WriteLine("                                                   *********************************        ");
            Console.WriteLine("                                                   **        1. Log  IN           **        ");
            Console.WriteLine("                                                   **        2. SIGN IN           **        ");
            Console.WriteLine("                                                   **        3. EXIT              **        ");
            Console.WriteLine("                                                   *********************************        ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("                                                                Enter Option: ");
            option = int.Parse(Console.ReadLine());
            if (option > 3 || option < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("OOPS! Wrong option.Try again.\n");
                Console.Write("Press any key to continue:");
                Console.ReadLine();
                Console.Clear();

            }
            return option;
        }


        /*

        //function for loading or reading data from file
        static bool read_data(string path, List<login> users)
        {
            if (File.Exists(path))
            {
                StreamReader fv = new StreamReader(path);
                // Create a StreamReader to read from the file
                string record;
                // Read each line from the file until the end is reached
                while ((record = fv.ReadLine()) != null)
                {
                    // Parse data from the current line using the parse_data function
                    string name = parse_data(record, 1);

                    string password = parse_data(record, 2);
                    string role = parse_data(record, 3);
                    // Create a new login object using the parsed data
                    login user = new login(name, password, role);
                    // Store the created login object in a list (assuming the storedatainlist function does that)
                    storedatainlist(users, user);


                }
                fv.Close();
                return true;
            }
            return false;
        }
        static string parse_data(string record, int field)
        {
            //use to keep track track of current field
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                //if in record string i.e. each line program gets comma increment comma
                if ((record[x] == ','))
                {
                    comma++;
                }
                //if current character is not comma place it in item and return it to store
                else if (comma == field)
                {
                    item = item + record[x];
                }


            }
            return item;
        }


        static login loginx()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"                                                                 
                         ..............-                         
                    =.......................#                    
                ........-===============-.......-                
              .....-=======+++++++++++++=====.....:              
           .....:=====++=..............:+++++++=:....            
          ....-====++......................:++++++-....          
        ....-===++............................-+++++-...-        
       ....===++................................:+++++...:       
      ...-===+:...................................=++++-...      
     ...===++.......................................*+++-...     
    ...==+++.........................................++++-..=    
   ....++++...........................................*+++...+   
   ...++++............................................=+++=...   
  #..:+++=..#@+......@@@@@@....@@@@@@...@@-.+@@:..@@-..*+++...   
  ...++++:..%@#.....@@%..@@@..@@*..#@+..@@-.*@@@..@@=..=+++-..   
  ...++++...@@#....-@@....@@.:@@........@@=.#@@@@.@@=...*++=..   
  ...++++...@@#....-@@....@@.-@@..@@@@..@@=.#@@=@@@@=...*++=..   
  ...++++...@@%.....@@#..@@@..@@+...@@..@@=.%@@.#@@@=...*++=..   
  :..++++:..@@@@@@@..@@@@@@...-@@@@@@%..@@=.%@@..@@@=..=*++-..   
   ..:++++.............................................#+++...   
   ...++++-...........................................+*++=...   
   ...:++++..........................................:#+++...    
    ...=++++.........................................#+++:..     
     ...=++++......................................-#+++:...     
      ...=++++=...................................+*+++:...      
       ....+++++-...............................=#+++=...        
        ....=+++++=...........................+#++++-...         
          ....=++++++=.....................+**++++-....          
            ....-+++++++*=:...........:+#*+++++=:....            
              .....-+++++++++++++++++++++++++.....               
                :......:==+++++++++++++=-.......                 
                     .......................                     
                                                  
                                                                 ");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\t\t\t\tEnter username: ");
            string username = Console.ReadLine();
            Console.Write("\t\t\t\tEnter password: ");
            string password = Console.ReadLine();

            if (username != null && password != null)
            {
                login user = new login(username, password);
                return user;
            }
            return null;
        }



        static login signinx(List<loginBL> users)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.Write("Enter role(owner/customer): ");
            string role = Console.ReadLine();

            // Check if the username already exists
            if (users.Any(u => u.username == username))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Username already exists. Please choose a different username.");
                return null;
            }

            if (username != null && password != null && role != null)
            {
                login user = new login(username, password, role);
                return user;
            }
            return null;
        }


        //it appends a login object to a list of login objects.
        static void storedatainlist(List<login> users, login user)
        {
            users.Add(user);
        }

        // It opens a file for writing using a StreamWriter, appends data to the file in CSV (comma-separated values) format, and then closes the file.
        static void storedatainfile(string path, login user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.username + "," + user.password + "," + user.role);
            file.Flush();
            file.Close();
        }


        static login signin(login user, List<login> users)
        {
            foreach (login stored_item in users)
            {
                if (user.username == stored_item.username && user.password == stored_item.password)
                {
                    return stored_item;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Account does not exist. Please check your username and password.");
            return null;
        }

        static string Owner()
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

        static void add_product_for_owner(string path1, List<owner> owner_data)
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
            string opr = Console.ReadLine();

            // Check if the product already exists in owner_data
            owner existingProduct = owner_data.Find(p => p.owner_product.Equals(opr, StringComparison.OrdinalIgnoreCase));

            if (existingProduct != null)
            {
                // Product already exists, ask for additional quantity
                Console.Write("\t\t\tProduct already exists. Enter additional quantity: ");
                int additionalQuantity = int.Parse(Console.ReadLine());
                existingProduct.owner_quantity += additionalQuantity;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Quantity updated for {existingProduct.owner_product}. Total quantity: {existingProduct.owner_quantity}");
            }
            else
            {
                // Product does not exist, ask for quantity and price
                Console.Write("\t\t\tEnter the quantity: ");
                int opq = int.Parse(Console.ReadLine());
                Console.Write("\t\t\tEnter the price: ");
                float opp = float.Parse(Console.ReadLine());

                owner owner_obj = new owner(opr, opq, opp);
                owner_data.Add(owner_obj);

                if (owner_obj != null)
                {
                    //if object is not null store it in the file and in the list declared above
                    storedatainfile1(path1, owner_data);


                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Product added successfully!");
            }

            Console.Write("Press any key to continue.....");
            Console.ReadKey();
        }


        static void show_owner(List<owner> owner_data)
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


        static void ChangePriceForProduct(List<owner> owner_data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the product for which you want to change the price: ");
            string productToChange = Console.ReadLine();

            // Find the product in the list
            owner product = owner_data.Find(p => p.owner_product.Equals(productToChange, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                Console.WriteLine($"Current price for {product.owner_product}: {product.owner_price}");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Enter the new price: ");
                float newPrice = float.Parse(Console.ReadLine());

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


        static void GiveDiscountForProduct(List<owner> owner_data)
        {
            Console.WriteLine("Enter the product for which you want to give a discount: ");
            string productToDiscount = Console.ReadLine();

            // Find the product in the list
            owner product = owner_data.Find(p => p.owner_product.Equals(productToDiscount, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                Console.WriteLine($"Current price for {product.owner_product}: {product.owner_price}");
                Console.Write("Enter the discount percentage: ");
                float discountPercentage = float.Parse(Console.ReadLine());

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




        static bool read_data1(string path1, List<owner> owner_data)
        {
            if (File.Exists(path1))
            {
                StreamReader fv = new StreamReader(path1);
                // Create a StreamReader to read from the file
                string record;
                // Read each line from the file until the end is reached
                while ((record = fv.ReadLine()) != null)
                {
                    string product = parse_data(record, 1);
                    if (int.TryParse(parse_data(record, 2), out int quantity))
                    {
                        float price;
                        if (float.TryParse(parse_data(record, 3), out price))
                        {
                            owner owner_obj = new owner(product, quantity, price);
                            owner_data.Add(owner_obj);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid price format in the record: {record}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid quantity format in the record: {record}");
                    }
                }
                fv.Close();
                return true;
            }
            return false;
        }



        // It opens a file for writing using a StreamWriter, appends data to the file in CSV (comma-separated values) format, and then closes the file.
        static void storedatainfile1(string path1, List<owner> owner_data)
        {
            List<string> lines = new List<string>();

            foreach (owner user in owner_data)
            {
                string line = $"{user.owner_product},{user.owner_quantity},{user.owner_price}";
                lines.Add(line);
            }

            // Write the updated data to the file
            File.WriteAllLines(path1, lines);
        }



        static string Customer()
        {
            string opc;
            int cursorTop = Math.Min(Console.WindowTop + 5, Console.BufferHeight - 1);

            Console.SetCursorPosition(10, cursorTop);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@" 
         __   __
       /|  `-´  |\
      /_|  o.o  |_\
        | o`o´o |
        |  o^o  |
        |_______|");
            Console.SetCursorPosition(0, 0);
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


        static void add_to_cart(List<customer> customer_cdata, List<owner> owner_data)
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
            owner product = owner_data.Find(p => p.owner_product.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                Console.WriteLine($"\tAvailable quantity for {product.owner_product}: {product.owner_quantity}\n");
                Console.Write("\t\tEnter the quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                // Check if the entered quantity is less than or equal to the available quantity
                if (quantity > 0 && quantity <= product.owner_quantity)
                {
                    Console.Write("\t\tEnter the size: ");
                    string size = Console.ReadLine();

                    // Check if the customer has already purchased the same product with the same size
                    customer existingItem = customer_cdata.Find(item => item.customer_product.Equals(name, StringComparison.OrdinalIgnoreCase) && item.customer_size.Equals(size, StringComparison.OrdinalIgnoreCase));

                    if (existingItem != null)
                    {
                        Console.Write($"\tYou have already purchased {existingItem.customer_quantity} {existingItem.customer_size} of {existingItem.customer_product}. Enter additional quantity: ");
                        int additionalQuantity = int.Parse(Console.ReadLine());
                        existingItem.customer_quantity += additionalQuantity;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\tQuantity updated for {existingItem.customer_product}. Total quantity: {existingItem.customer_quantity}\n");

                    }
                    else
                    {
                        product.owner_quantity -= quantity;

                        customer cust_obj = new customer(name, quantity, size);
                        customer_cdata.Add(cust_obj);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t\tProduct added successfully to cart.\n");
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
            }
            Console.WriteLine("\t\tPress any key to continue...");
            Console.ReadKey();
        }


        static void buy_customer(List<customer> customer_cdata, List<customer> customer_bdata)
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
            customer product = customer_cdata.Find(p => p.customer_product.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                Console.WriteLine($"\t\tAvailable quantity for {product.customer_product}: {product.customer_quantity}\n");
                Console.Write("\t\tEnter the quantity to purchase: ");
                int purchaseQuantity = int.Parse(Console.ReadLine());

                // Check if the entered quantity is less than or equal to the available quantity
                if (purchaseQuantity > 0 && purchaseQuantity <= product.customer_quantity)
                {
                    Console.Write("\t\tEnter the size: ");
                    string size = Console.ReadLine();

                    // Reduce the available quantity in the customer_cdata list
                    product.customer_quantity -= purchaseQuantity;

                    // Add the purchased product to the customer_bdata list
                    customer_bdata.Add(new customer(name, purchaseQuantity, size));

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\t\tProduct purchased successfully.\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tInvalid quantity. Please enter a valid quantity within the available stock.\n");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\tProduct not found. Please check the product name.\n");
            }
            Console.WriteLine("\t\tPress any key to continue...");
            Console.ReadKey();
        }

        static void show_customer(List<owner> owner_data, List<customer> customer_bdata)
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
            customer obj = new customer();
            total = obj.total_bill(owner_data, customer_bdata);

            Console.WriteLine();
            Console.WriteLine("\t\t---------------------------------------");
            Console.WriteLine("\t\tTotal bill is..... |  " + total + ".00_/RS  |");
            Console.WriteLine("\t\t---------------------------------------");

            Console.Write("Press any key to continue.....");
            Console.ReadKey();
        }

        */

    }
}