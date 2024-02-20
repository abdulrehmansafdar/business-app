using self1.DL;
using self1.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student_BL student = Student_UI.Add_student();
            Student_DL.StoreStudent(student);
        }
    }
}
