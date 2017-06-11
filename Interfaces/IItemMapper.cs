using PricingBasket.Objects;
using System.Collections.Generic;

namespace PricingBasket.Interfaces
{
    public interface IItemMapper
    {
        List<Item> MapStringToItemList(string items);
    }
}
