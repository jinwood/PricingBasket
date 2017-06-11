using PricingBasket.OfferLogic;
using System.Collections.Generic;

namespace PricingBasket.Objects
{
    public class Basket
    {
        public List<Item> Items { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal DiscountedPrice { get; set; }

        public Basket()
        {
            Items = new List<Item>();
        }

        //in a production system the item prices should not be hardcoded
        //perhaps fetched from a db or external service

        //the offer logic should be fetched via a factory method (todo)
        public void SetPrices()
        {
            foreach (var item in Items)
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
                        item.Price = 0m;
                        break;
                }
            }
        }

        public decimal TotalPrice()
        {
            var totalPrice = 0.0m;

            foreach (var item in Items)
            {
                totalPrice += item.Price;
            }
            return totalPrice;
        }
    }
}
