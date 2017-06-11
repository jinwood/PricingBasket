using System.Collections.Generic;

namespace PricingBasket.Objects
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public List<Offer> Offers { get; set; }
    }
}
