using PricingBasket.Objects;
using System.Collections.Generic;

namespace PricingBasket.Interfaces
{
    public interface IOfferLogicFactory
    {
        List<IOfferLogic> GetLogicForItem(ItemType type);
    }
}
