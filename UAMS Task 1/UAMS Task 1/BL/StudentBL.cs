using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS
{
    internal class StudentBL
    {
        public string Name;
        public int Age;
        public double FSCMarks;
        public double EcatMarks;
        public double Merit;
        public List<DegreeProgramBL> Preferences;
        public List<SubjectBL> RegSubject;
        public DegreeProgramBL RegDegree;

        public StudentBL(string Name, int Age, double FSCMarks, double EcatMarks, List<DegreeProgramBL> Preferences)
        {
            this.Name = Name;
            this.Age = Age;
            this.FSCMarks = FSCMarks;
            this.EcatMarks = EcatMarks;
            this.Preferences = Preferences;
            RegSubject = new List<SubjectBL>();

        }

        public void CalculateMerit()
        {
            this.Merit = (((FSCMarks / 1100) * 0.45F) + ((EcatMarks / 400) * 0.55f)) * 100;
        }

        public bool RegStudentSubject(SubjectBL s)
        {
            int StCH = GetCreditHours();
            if (RegDegree != null && RegDegree.IsSubjectExists(s) && StCH + s.CreditHours <= 9)
            {
                RegSubject.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }



        public int GetCreditHours()
        {
            int Count = 0;
            foreach (SubjectBL sub in RegSubject)
            {
                Count = Count + sub.CreditHours;
            }
            return Count;
        }

        public float CalculateFee()
        {
            float Fee = 0;
            if (RegDegree != null)
            {
                foreach (SubjectBL sub in RegSubject)
                {
                    Fee = Fee + sub.SubjectFees;
                }
            }
            return Fee;
        }

        public static void GiveAdmission(List<StudentBL> SortedStudentList)
        {
            foreach (StudentBL s in SortedStudentList)
            {
                foreach (DegreeProgramBL d in s.Preferences)
                {
                    if (d.Seats > 0 && s.RegDegree == null)
                    {
                        s.RegDegree = d;
                        d.Seats--;
                        break;
                    }
                }
            }
        }


        public static StudentBL StudentPresent(string Name)
        {
            foreach (StudentBL s in StudentDL.StudentList)
            {
                if (Name == s.Name && s.RegDegree != null)
                {
                    return s;
                }
            }

            return null;
        }

        
    }
}
