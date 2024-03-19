using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signl_ogin
{
    internal class ownerDL
    {
        static List<ownerBL> owner_data = new List<ownerBL>();
        public static List<ownerBL> GetOwnerData()
        {
            // Return the list of ownerBL objects
            return owner_data;
        }

        public static void AddProductToList(List<ownerBL> owner_data, ownerBL newProduct)
        {
            // Add the new product to the owner_data list
            owner_data.Add(newProduct);

            // Save the updated data to the file
            storedatainfile1("owner.txt", owner_data);
        }

        public static bool read_data1(string path1, List<ownerBL> owner_data)
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
                            ownerBL owner_obj = new ownerBL(product, quantity, price);
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
       public static void storedatainfile1(string path1, List<ownerBL> owner_data)
        {
            List<string> lines = new List<string>();

            foreach (ownerBL user in owner_data)
            {
                string line = $"{user.owner_product},{user.owner_quantity},{user.owner_price}";
                lines.Add(line);
            }

            // Write the updated data to the file
            File.WriteAllLines(path1, lines);
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

    }
}
