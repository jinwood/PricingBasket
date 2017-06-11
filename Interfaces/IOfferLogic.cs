using PricingBasket.Objects;
using System.Collections.Generic;

namespace PricingBasket.Interfaces
{
    public interface IOfferLogic
    {
        bool IsOfferApplicable(List<Item> items);
        decimal NewItemsPrice(List<Item> items);
    }
}
