using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self1
{
    internal class Student_BL
    {
        public string Name;
        public int Age;
        public double Fsc;
        public double Ecat;
        public double Merit;

        public Student_BL(string name, int age, double fsc, double ecat)
        {
            this.Name = name;
            this.Age = age;
            this.Fsc = fsc;
            this.Ecat = ecat;
            
        }

    }
}
