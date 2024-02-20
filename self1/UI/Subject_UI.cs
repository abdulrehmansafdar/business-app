using self1.BL;
using self1.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self1.UI
{
    internal class Subject_UI
    {
        public  void AddSubjectDetails()
        {
            Console.WriteLine("Enter subject code: ");
            int code = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter type: ");
            string type=Console.ReadLine();
            Console.WriteLine("Enter credit hours: ");
            int cr=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter fee: ");
            int fee =int.Parse(Console.ReadLine());
           
        }
    }
}
