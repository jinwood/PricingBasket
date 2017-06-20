using PricingBasket.Factories;
using PricingBasket.Interfaces;
using PricingBasket.Objects;
using System;
using System.Globalization;
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
            if (basket == null) return null;

            var types = Enum.GetValues(typeof(ItemType)).Cast<ItemType>();
            var offerLogicFactory = new OfferLogicFactory();
            bool? basketContainsOffers = null;

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
                    basketContainsOffers = false;
                    continue;
                }

                foreach (var logic in offerLogic)
                {
                    if (logic.IsOfferApplicable(itemsOfType))
                    {
                        basketContainsOffers = true;
                        var discount = logic.Discount(itemsOfType);
                        basket.TotalDiscount += discount;
                        Console.WriteLine($"{type} {logic.Description}: -{discount.ToString("C",CultureInfo.CurrentCulture)}");
                    }
                    else
                    {
                        if(basketContainsOffers != null) basketContainsOffers = false;
                    }
                }
            }
            basket.DiscountedPrice = basket.TotalPrice() - basket.TotalDiscount;

            if (basketContainsOffers != null && !(bool)basketContainsOffers) Console.WriteLine($"(No offers available)");

            return basket;
        }
    }
}
