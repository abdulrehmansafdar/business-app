using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS
{
    internal class SubjectBL
    {
        public string Code;
        public string Type;
        public int CreditHours;
        public int SubjectFees;

        public SubjectBL(string Code, string Type, int CreditHours, int SubjectFees)

        {

            this.Code = Code;
            this.Type = Type;
            this.CreditHours = CreditHours;
            this.SubjectFees = SubjectFees;

        }
       
    }
}
