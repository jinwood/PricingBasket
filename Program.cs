using PricingBasket.Factories;
using PricingBasket.Objects;
using System;
using System.Linq;

namespace PricingBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            var basket = new Basket();

            basket.Items.Add(new Item
            {
                Type = ItemType.Bread
            });
            basket.Items.Add(new Item
            {
                Type = ItemType.Bread
            });

            basket.Items.Add(new Item
            {
                Type = ItemType.Apple
            });
            basket.Items.Add(new Item
            {
                Type = ItemType.Apple
            });
            basket.Items.Add(new Item
            {
                Type = ItemType.Apple
            });
            basket.Items.Add(new Item
            {
                Type = ItemType.Apple
            });

            basket.Items.Add(new Item
            {
                Type = ItemType.Soup
            });
            basket.Items.Add(new Item
            {
                Type = ItemType.Soup
            });
            basket.Items.Add(new Item
            {
                Type = ItemType.Soup
            });
            basket.Items.Add(new Item
            {
                Type = ItemType.Soup
            });
            basket.Items.Add(new Item
            {
                Type = ItemType.Soup
            });
            basket.Items.Add(new Item
            {
                Type = ItemType.Soup
            });
            basket.Items.Add(new Item
            {
                Type = ItemType.Soup
            });

            basket.SetPrices();

            Console.WriteLine($"Subtotal: \u00A3 {basket.TotalPrice()}");
            SetDiscounts(basket);
            Console.WriteLine($"Total: \u00A3{basket.DiscountedPrice}");
            Console.ReadLine();
        }

        private static void SetDiscounts(Basket basket)
        {
            var types = Enum.GetValues(typeof(ItemType)).Cast<ItemType>();
            var offerFactory = new OfferFactory();

            foreach (var type in types)
            {
                if (type == ItemType.Unknown)
                    continue;

                if (!basket.Items.Any(x => x.Type == type))
                    continue;

                var itemsOfType = basket.Items.Where(x => x.Type == type).ToList();
                var offerLogic = offerFactory.GetLogicForItem(itemsOfType.FirstOrDefault());

                if (offerLogic == null)
                {
                    Console.WriteLine($"{type} - (No offers available)");
                    continue;
                }

                foreach (var logic in offerLogic)
                {
                    if (logic.IsOfferApplicable(itemsOfType))
                    {
                        var discount = logic.Discount(itemsOfType);
                        basket.TotalDiscount += discount;
                        Console.WriteLine($"{type} {logic.Description}: - \u00A3{discount}");
                    }
                    else
                    {
                        Console.WriteLine("(No offers available)");
                    }

                }


            }
            basket.DiscountedPrice = basket.TotalPrice() - basket.TotalDiscount;
        }
    }

    
}