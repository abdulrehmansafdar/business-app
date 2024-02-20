using self1.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self1.DL
{
    internal class Student_DL
    {

       static List<Student_BL> StudentData = new List<Student_BL>();
        public static void StoreStudent(Student_BL s)
        {
           
            if (s == null)
            {
                StudentData.Add(s);
                
            }
        }
    }
}
