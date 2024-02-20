using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signl_ogin
{
    class customer
    {
        public string customer_product;
        public int customer_quantity;
        public string customer_size;
        public customer(string customerp, int customerq, string customers)
        {
            customer_product = customerp;
            customer_quantity = customerq;
            customer_size = customers;
        }
        public float total_bill(List<owner> owner_data, List<customer> customer_bdata)
        {
            float total = 0;

            // Iterate through the customer's cart
            foreach (var item in customer_bdata)
            {
                // Find the product in the owner_data list
                owner product = owner_data.Find(p => p.owner_product.Equals(item.customer_product, StringComparison.OrdinalIgnoreCase));

                if (product != null)
                {
                    // Calculate the total based on quantity and price
                    total += item.customer_quantity * product.owner_price;
                }
            }

            return total;
        }
        public customer()
        { }

    }

}