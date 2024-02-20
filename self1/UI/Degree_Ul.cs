using self1.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self1.UI
{
    internal class Degree_Ul
    {
        public static void Add_degree()
        {
            Console.WriteLine("Enter degree name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the degree duration: ");
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the seats: ");
            int seats = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of subjects: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Subject_UI s = new Subject_UI();
                s.AddSubjectDetails();
                
            }

        }
    }
}
