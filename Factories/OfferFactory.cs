using PricingBasket.Interfaces;
using PricingBasket.Objects;
using PricingBasket.OfferLogic;
using System.Collections.Generic;

namespace PricingBasket.Factories
{
    public class OfferFactory : IOfferLogicFactory
    {
        public List<IOfferLogic> GetLogicForItem(Item item)
        {
            if (item == null)
                return null;
            switch (item.Type)
            {
                case ItemType.Apple:
                    return new List<IOfferLogic> { new TenPercentOff() };
                case ItemType.Bread:
                case ItemType.Milk:
                case ItemType.Unknown:
                    return null;
                case ItemType.Soup:
                    return new List<IOfferLogic> { new ThirdItemHalfPrice() };
                default:
                    return null;
            }
        }
    }
}
