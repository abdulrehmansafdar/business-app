using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UAMS
{
    internal class StudentDL
    {
        public static List<StudentBL> StudentList = new List<StudentBL>();

        public static void AddIntoStudentList(StudentBL s)
        {
            StudentList.Add(s);
        }

        public static List<StudentBL> SortStudentsByMerit()
        {
            List<StudentBL> sortedStudentList = new List<StudentBL>();
            foreach (StudentBL s in StudentList)
            {
                s.CalculateMerit();
            }

            sortedStudentList = StudentList.OrderByDescending(o => o.Merit).ToList();
            return sortedStudentList;
        }
    }
}
