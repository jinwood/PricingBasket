using Microsoft.VisualStudio.TestTools.UnitTesting;
using PricingBasket.Factories;
using PricingBasket.Interfaces;
using PricingBasket.Objects;
using System.Collections.Generic;
using System;
using System.Linq;

namespace PricingBasket.Test
{
    [TestClass]
    public class DiscountProcessor_TestFixtures
    {
        [TestMethod]
        public void DiscountProcessor_NullBasket_ReturnsNull()
        {
            //arrange
            var processor = new DiscountProcessor();

            //act
            var basket = processor.SetBasketDiscounts(null);

            //assert
            Assert.AreEqual(null, basket);
        }

        [TestMethod]
        public void DiscountProcessor_Apple_ReturnsCorrectPrice()
        {
            //arrange
            var basket = new Basket
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Type = ItemType.Apple
                    }
                }
            };

            var priceFactory = new TestPriceFactory();

            //act
            priceFactory.SetItemPrices(basket.Items);

            //assert
            Assert.AreEqual(1.00m, basket.Items.FirstOrDefault(x => x.Type == ItemType.Apple).Price);
        }

        [TestMethod]
        public void DiscountProcessor_Apple_AppliesCorrectDiscountedPrice()
        {
            //arrange
            var basket = new Basket
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Type = ItemType.Apple
                    }
                }
            };
            var offerLogicFactory = new OfferLogicFactory();
            var priceFactory = new TestPriceFactory();
            var offerLogic = offerLogicFactory.GetLogicForItem(basket.Items.FirstOrDefault().Type);

            //act
            priceFactory.SetItemPrices(basket.Items);
            foreach (var logic in offerLogic)
            {
                var discount = logic.Discount(basket.Items);
                basket.TotalDiscount += discount;
            }

            //assert
            Assert.AreEqual(0.10m, basket.TotalDiscount);
        }
    }

    public class TestPriceFactory : IPriceFactory
    {
        public List<Item> SetItemPrices(List<Item> items)
        {
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
