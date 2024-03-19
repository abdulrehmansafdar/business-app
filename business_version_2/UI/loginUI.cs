using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signl_ogin
{
    internal class loginUI
    {
        public static loginBL loginx()
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
                loginBL user = new loginBL(username, password);
                return user;
            }
            return null;
        }



        public static loginBL signinx(List<loginBL> users)
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
                loginBL user = new loginBL(username, password, role);
                return user;
            }
            return null;
        }
        public static loginBL signin(loginBL user ,List<loginBL> users)
        {
            foreach (loginBL stored_item in users)
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
    }
}
