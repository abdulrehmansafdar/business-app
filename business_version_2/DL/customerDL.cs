using signl_ogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task01.DL
{
    internal class customerDL
    {
       static List<customerBL> customer_cdata = new List<customerBL>();
       static List<customerBL> customer_bdata = new List<customerBL>();

        public static List<customerBL> Getcustomer1Data()
        {
            // Return the list of ownerBL objects
            return customer_cdata;
        }
        public static List<customerBL> Getcustomer2Data()
        {
            // Return the list of ownerBL objects
            return customer_bdata;
        }
        public static void addcartlist(customerBL c)
        {
            customer_cdata.Add(c);
        }
        public static void addbuylist(customerBL c)
        {
            customer_bdata.Add(c);
        }
    }
}
