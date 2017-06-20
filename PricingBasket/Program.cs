/*
 This is my solution to the BJSS Coding test
 I'm fairly happy with how it has turned out. It satisfies all the conditions outlined in the
 assignment. There are some hardcoded values such as pricings, which in a production environment
 you would not want to use, but for the purpose of this test I thought it would be OK to leave for now.

 Improvements I would make given more time:
 - Implement IOC. Currently the solution is not very flexible, and there are some hard dependencies between
   most of the classes used. For example, what if we wanted to use an OfferLogicFactory that took in 
   discount codes and then used an external service to validate them? What if we wanted to test different implementations
   of the concrete classes? Not possible currently. Some of the classes could be static (ItemMapper for example).
 - Restrict the user input. The program currently allows any form of input string. It would be more appropriate to 
   have a UI over the top of this and not rely on the user to type the correct thing!
   
 */
using PricingBasket.Factories;
using PricingBasket.Objects;
using System;
using System.Globalization;

namespace PricingBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Enter items, seperated by spaces");
            var items = Console.ReadLine();

            var basket = new Basket()
            {
                Items = new ItemMapper().MapStringToItemList(items)
            };

            var priceFactory = new PriceFactory();
            priceFactory.SetItemPrices(basket.Items);

            Console.WriteLine($"Subtotal: £ {basket.TotalPrice().ToString("C", CultureInfo.CurrentCulture)}");
            var processor = new DiscountProcessor();
            processor.SetBasketDiscounts(basket);
            Console.WriteLine($"Total: {basket.DiscountedPrice.ToString("C",CultureInfo.CurrentCulture)}");
            Environment.Exit(0);
        }
    }

    
}