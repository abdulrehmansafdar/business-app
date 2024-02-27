using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS
{
    internal class DegreeProgramBL
    {
        public string DegreeName;
        public float DegreeDuration;
        public List<SubjectBL> Subjects;
        public int Seats;

        public DegreeProgramBL(string DegreeName, float DegreeDuration, int Seats)
        {
            this.DegreeName = DegreeName;
            this.DegreeDuration = DegreeDuration;
            this.Seats = Seats;
            Subjects = new List<SubjectBL>();
        }

        public int CalcualateCreditHours()
        {
            int Count = 0;
            for (int i = 0; i < Subjects.Count; i++)
            {
                Count = Count + Subjects[i].CreditHours;
            }
            return Count;
        }

        public bool AddSubject(SubjectBL s)
        {
            int CreditHours = CalcualateCreditHours();

            if (CreditHours + s.CreditHours <= 20)
            {
                Subjects.Add(s);
                SubjectDL.StoreSubjectsInFile("subject.txt", s);
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool IsSubjectExists(SubjectBL sub)
        {
            foreach (SubjectBL s in Subjects)
            {
                if (s.Code == sub.Code)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
