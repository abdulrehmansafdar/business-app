using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self1.BL
{
    internal class Subject_BL
    {
        public int Code;
        public int  Credithours;
        public string Type;
        public int Fee;

        public Subject_BL(int code, string type, int credithours, int fee)
        {
            this.Code = code;
            this.Credithours = credithours;
            this.Type = type;
            this.Fee = fee;
        }
    }
}
