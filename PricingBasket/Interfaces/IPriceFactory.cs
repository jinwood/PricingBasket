using PricingBasket.Objects;
using System.Collections.Generic;

namespace PricingBasket.Interfaces
{
    public interface IPriceFactory
    {
        List<Item> SetItemPrices(List<Item> items);
    }
}
