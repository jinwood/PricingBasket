
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PricingBasket.Objects;
using PricingBasket.OfferLogic;
using System.Collections.Generic;

namespace PricingBasket.Test.OfferLogic
{
    [TestClass]
    public class ThirdItemHalfPrice_TestFixture
    {
        [TestMethod]
        public void ThirdItemHalfPrice_IsOfferApplicable_ReturnsFalse()
        {
            //arrange
            var items = new List<Item>
            {
                new Item
                {
                    Type = ItemType.Soup
                }
            };

            //act 
            var result = new ThirdItemHalfPrice().IsOfferApplicable(items);

            //assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void ThirdItemHalfPrice_IsOfferApplicable_ReturnsTrue()
        {
            //arrange
            var items = new List<Item>
            {
                new Item
                {
                    Type = ItemType.Soup
                },
                new Item
                {
                    Type = ItemType.Soup
                },
                new Item
                {
                    Type = ItemType.Soup
                },
                new Item
                {
                    Type = ItemType.Soup
                },
                new Item
                {
                    Type = ItemType.Soup
                },
                new Item
                {
                    Type = ItemType.Soup
                },
            };

            //act 
            var result = new ThirdItemHalfPrice().IsOfferApplicable(items);

            //assert
            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void ThirdItemHalfPrice_IsOfferApplicable_ReturnsCorrectDiscount()
        {
            //arrange
            var items = new List<Item>
            {
                new Item
                {
                    Type = ItemType.Soup,
                    Price = 1m
                },
                new Item
                {
                    Type = ItemType.Soup,
                    Price = 1m
                },
                new Item
                {
                    Type = ItemType.Soup,
                    Price = 1m
                }
            };

            //act 
            var result = new ThirdItemHalfPrice().Discount(items);

            //assert
            Assert.AreEqual(0.5m, result);
        }
    }
}
