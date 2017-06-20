using PricingBasket.Interfaces;
using PricingBasket.Objects;
using System.Collections.Generic;

namespace PricingBasket.Factories
{
    public class PriceFactory : IPriceFactory
    {
        //in a production system the item prices should not be hardcoded
        //perhaps fetched from a db or external service
        public List<Item> SetItemPrices(List<Item> items)
        {
            if (items == null) return null;

            foreach (var item in items)
            {
                switch (item.Type)
                {
                    case ItemType.Apple:
                        item.Price = 1.00m;
                        break;
                    case ItemType.Bread:
                        item.Price = 0.80m;
                        break;
                    case ItemType.Milk:
                        item.Price = 1.30m;
                        break;
                    case ItemType.Soup:
                        item.Price = 0.65m;
                        break;
                    case ItemType.Unknown:
                    default:
                        item.Price = 0m;
                        break;
                }
            }
            return items;
        }
    }
}
