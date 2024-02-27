using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UAMS
{
    internal class DegreeProgramDL
    {
       public static  List<DegreeProgramBL> ProgramList = new List<DegreeProgramBL>();
        
         public static void AddIntoDegreeList(DegreeProgramBL d)
        {
            ProgramList.Add(d);
        }
       
    }
}
