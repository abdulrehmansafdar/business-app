using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace signl_ogin
{
    class ownerBL
    {
        public string owner_product;
        public int owner_quantity;
        public float owner_price;
        public ownerBL(string owner_product, int owner_quantity, float owner_price)
        {
            this.owner_product = owner_product;
            this.owner_quantity = owner_quantity;
            this.owner_price = owner_price;
        }
        public void ChangePrice(float newPrice)
        {
            owner_price = newPrice;
            Console.WriteLine($"Price for {owner_product} has been changed to {newPrice}.");
        }
        public void GiveDiscount(float discountPercentage)
        {
            float discountAmount = owner_price * (discountPercentage / 100);
            owner_price -= discountAmount;

            Console.WriteLine($"Discount of {discountPercentage}% applied to {owner_product}. New price: {owner_price}");
        }
      
      

       




    }
}