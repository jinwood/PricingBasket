using System.Collections.Generic;
using PricingBasket.Interfaces;
using PricingBasket.Objects;
using System.Linq;

namespace PricingBasket.OfferLogic
{
    public class ThirdItemHalfPrice : IOfferLogic
    {
        public string Description => "Third item half price";

        public bool IsOfferApplicable(List<Item> items)
        {
            if (items.Where(i => i.Type == ItemType.Soup).ToList().Count >= 3)
                return true;

            return false;
        }

        public decimal Discount(List<Item> items)
        {
            var matchedItems = items.Where(i => i.Type == ItemType.Soup).ToList();
            var pricePerItem = matchedItems.FirstOrDefault().Price;
            var currentPrice = matchedItems.Count * pricePerItem;

            var toDiscount = matchedItems.Count / 3;

            return (pricePerItem * 0.5m) * toDiscount;
        }
    }
}
