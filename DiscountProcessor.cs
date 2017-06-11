using PricingBasket.Factories;
using PricingBasket.Interfaces;
using PricingBasket.Objects;
using System;
using System.Linq;

namespace PricingBasket
{
    public class DiscountProcessor : IDiscountProcessor
    {
        //I really don't like this name but couldn't think of
        //anything more appropriate. Perhaps the code should live
        //in a method within the Basket class?
        public Basket SetBasketDiscounts(Basket basket)
        {
            var types = Enum.GetValues(typeof(ItemType)).Cast<ItemType>();
            var offerLogicFactory = new OfferLogicFactory();

            //iterate over all available item types so we can 
            //break up our item list by type and apply discounts
            foreach (var type in types)
            {
                if (type == ItemType.Unknown)
                    continue;

                if (!basket.Items.Any(x => x.Type == type))
                    continue;

                var itemsOfType = basket.Items.Where(x => x.Type == type).ToList();
                var offerLogic = offerLogicFactory.GetLogicForItem(type);

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

            return basket;
        }
    }
}
