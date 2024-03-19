using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signl_ogin
{
    internal class loginDL
    {
       static List<loginBL> users = new List<loginBL>();
        public static List<loginBL> GetuserData()
        {
            // Return the list of ownerBL objects
            return users;
        }
        public static bool read_data(string path, List<loginBL> users)
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
                    loginBL user = new loginBL(name, password, role);
                    // Store the created login object in a list (assuming the storedatainlist function does that)
                    storedatainlist( user);


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
       public  static void storedatainlist( loginBL user)
        {
            users.Add(user);
        }

        // It opens a file for writing using a StreamWriter, appends data to the file in CSV (comma-separated values) format, and then closes the file.
       public  static void storedatainfile(string path, loginBL user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.username + "," + user.password + "," + user.role);
            file.Flush();
            file.Close();
        }

    }
}
