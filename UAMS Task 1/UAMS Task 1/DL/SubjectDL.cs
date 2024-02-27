using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UAMS
{
    internal class SubjectDL
    {
        List<SubjectBL> AllSubjects = new List<SubjectBL>();
        public static void StoreSubjectsInFile(string path, SubjectBL d)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(d.Code + "," + d.Type + "," + d.CreditHours + "," + d.SubjectFees);
            file.Flush();
            file.Close();
        }
    }
}
