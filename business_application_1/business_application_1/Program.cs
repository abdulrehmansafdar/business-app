using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace signl_ogin
{
    class Program
    {
        static void Main(string[] args)
        {
            //create list named login
            List<login> users = new List<login>();
            List<owner> owner_data = new List<owner>();
            int owner_index = 0;
            string opc;
            //filename
            string path = "textfile.txt";
            string path1 = "owner.txt";
            string op1 ;
            int option = 0;
            //function for reading data and show result on console
            bool check = read_data(path, users);
            bool check2= read_data1(path1 , owner_data);
           
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
                    login user = loginx();
                    if (user != null)
                    {
                        //if object is not empty  assign it returning value of signin
                        user = signin(user, users);


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
                            opc = Owner();
                            if (opc == "1")
                            {
                                Console.Clear();
                                add_product_for_owner(path1, owner_data);
                            }
                            else if (opc == "2")
                            {
                                Console.Clear();
                                ChangePriceForProduct(owner_data);
                            }
                            else if (opc == "3")
                            {
                                Console.Clear() ;
                                show_owner(owner_data);
                            }
                            else if (opc == "4")
                            {
                                Console.Clear();
                                GiveDiscountForProduct(owner_data);
                            }
                            else if (opc == "5")
                            {
                                Console.WriteLine(@"
                    _______  _____ _____ _____ ___ _   _  ____ 
                    | ____\ \/ /_ _|_   _|_   _|_ _| \ | |/ ___|
                    |  _|  \  / | |  | |   | |  | ||  \| | |  _ 
                    | |___ /  \ | |  | |   | |  | || |\  | |_| |
                    |_____/_/\_\___| |_|   |_| |___|_| \_|\____|");
                            }

                        } while (opc != "5");
                        storedatainfile1(path1, owner_data); 
                    }
                    else if(user.isCustomer())
                    {
                        Console.WriteLine("Customer Menu.");
                        Console.Clear();
                        do
                        {
                            Console.Clear();
                            op1 = Customer();
                            if (op1 == "1")
                            {
                                Console.Clear();
                                
                            }
                            else if (op1 == "2")
                            {
                                Console.Clear();
                                
                            }
                            else if (op1 == "3")
                            {
                                Console.Clear();
                               
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
                            }

                        } while (op1 != "5");
                    }
                }
                else if (option == 2)
                {
                    //now assign returning value of signinx to object named 'user'
                    login user = signinx(users);
                    if (user != null)
                    {
                        //if object is not null store it in the file and in the list declared above
                        storedatainfile(path, user);
                        
                        storedatainlist(users, user);
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



        static login signinx(List<login> users)
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
            Console.ForegroundColor= ConsoleColor.Red;
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

    }
}
