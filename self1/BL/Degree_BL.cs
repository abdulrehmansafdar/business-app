using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self1.BL
{
    internal class Degree_BL
    {
        public string Title;
        public int Duration;
        public int seats;

        public Degree_BL(string title, int duration,int seats)
        {
            this.Title = title;
            this.Duration = duration;
            this.seats = seats;
        }
    }
}
