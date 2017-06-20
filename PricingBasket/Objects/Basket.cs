using PricingBasket.OfferLogic;
using System.Collections.Generic;

namespace PricingBasket.Objects
{
    public class Basket
    {
        public List<Item> Items { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal DiscountedPrice { get; set; }

        public Basket()
        {
            Items = new List<Item>();
        }

        public decimal TotalPrice()
        {
            var totalPrice = 0.0m;

            foreach (var item in Items)
            {
                totalPrice += item.Price;
            }
            return totalPrice;
        }
    }
}
