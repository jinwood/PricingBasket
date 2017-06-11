using System.Collections.Generic;
using PricingBasket.Interfaces;
using PricingBasket.Objects;
using System.Linq;

namespace PricingBasket.OfferLogic
{
    public class TenPercentOff : IOfferLogic
    {
        public string Description => "10% off";

        public decimal Discount(List<Item> items)
        {
            var itemsOfType = items.Where(x => x.Type == ItemType.Apple);
            var totalCost = 0.00m;
            foreach (var item in items)
            {
                totalCost += item.Price;
            }

            return totalCost * 0.1m;
        }

        public bool IsOfferApplicable(List<Item> items)
        {
            if (items.Any(i => i.Type == ItemType.Apple))
                return true;

            return false;
        }
    }
}
