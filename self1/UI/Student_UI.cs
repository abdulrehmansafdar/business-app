using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self1.UI
{
    internal class Student_UI
    {
        public static  Student_BL Add_student()
        {
            Console.WriteLine("Enter the name of student: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Fsc marks: ");
            double fsc = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Ecat marks: ");
            double ecat = double.Parse(Console.ReadLine());
            Student_BL stu = new Student_BL(name, age, fsc, ecat);
            return stu;
        }
    }
}
