using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS
{
    internal class DegreeUI
    {
        public static void ViewDegreePrograms()
        {
            foreach (DegreeProgramBL dp in DegreeProgramDL.ProgramList)
            {
                Console.WriteLine(dp.DegreeName);
            }
        }

        public static DegreeProgramBL TakeInputForDegree()
        {
            string DegreeName;
            float DegreeDuration;
            int Seats;

            Console.Write("Enter Degree Name: ");
            DegreeName = Console.ReadLine();
            Console.Write("Enter Degree Duration: ");
            DegreeDuration = float.Parse(Console.ReadLine());
            Console.Write("Enter Seats for Degree: ");
            Seats = int.Parse(Console.ReadLine());

            DegreeProgramBL degProg = new DegreeProgramBL(DegreeName, DegreeDuration, Seats);
            Console.Write("Enter how many Subjects to Enter: ");
            int Count = int.Parse(Console.ReadLine());
            for (int i = 0; i < Count; i++)
            {
                degProg.AddSubject( SubjectUI.TakeInputForSubject());
            }

            return degProg;
        }

        public static string TakeDegree()
        {
            string degName;
            Console.Write("Enter Degree Name: ");
            degName = Console.ReadLine();
            return degName;
        }
    }
}
