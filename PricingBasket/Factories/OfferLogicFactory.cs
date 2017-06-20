using System;
using PricingBasket.Interfaces;
using PricingBasket.Objects;
using PricingBasket.OfferLogic;
using System.Collections.Generic;

namespace PricingBasket.Factories
{
    public class OfferLogicFactory : IOfferLogicFactory
    {
        public List<IOfferLogic> GetLogicForItem(ItemType type)
        {
            switch (type)
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
