using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace signl_ogin
{
    class customerBL
    {
        public string customer_product;
        public int customer_quantity;
        public string customer_size;
        public customerBL(string customerp, int customerq, string customers)
        {
            customer_product = customerp;
            customer_quantity = customerq;
            customer_size = customers;
        }
        public float total_bill(List<ownerBL> owner_data, List<customerBL> customer_bdata)
        {
            float total = 0;

            // Iterate through the customer's cart
            foreach (var item in customer_bdata)
            {
                // Find the product in the owner_data list
                ownerBL product = owner_data.Find(p => p.owner_product.Equals(item.customer_product, StringComparison.OrdinalIgnoreCase));

                if (product != null)
                {
                    // Calculate the total based on quantity and price
                    total += item.customer_quantity * product.owner_price;
                }
            }

            return total;
        }
        public customerBL()
        { }
      public  static ownerBL isProductInOwner(List<customerBL> customer_cdata, List<ownerBL> owner_data,string name)
        {
            // Check if the product exists in the owner_data list
            ownerBL product = owner_data.Find(p => p.owner_product.Equals(name, StringComparison.OrdinalIgnoreCase));
            return product;
        }

        public static customerBL isProductAlreadyFound(List<customerBL> customer_cdata, string name,string size)
        {
            // Check if the customer has already purchased the same product with the same size
            customerBL existingItem = customer_cdata.Find(item => item.customer_product.Equals(name, StringComparison.OrdinalIgnoreCase) && item.customer_size.Equals(size, StringComparison.OrdinalIgnoreCase));
return existingItem;

        }
        public static customerBL isProductInCart(List<customerBL> customer_cdata, string name)
            {
            // Check if the product exists in the customer_cdata list
            customerBL product = customer_cdata.Find(p => p.customer_product.Equals(name, StringComparison.OrdinalIgnoreCase));
            return product;
        }


    }

}