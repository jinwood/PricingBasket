using Microsoft.VisualStudio.TestTools.UnitTesting;
using PricingBasket.Objects;
using PricingBasket.OfferLogic;
using System;
using System.Collections.Generic;

namespace PricingBasket.Test.OfferLogic
{
    [TestClass]
    public class TenPercentOff_TestFixture
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TenPercentOff_NullItemType_ThrowsException()
        {
            //act
            var result = new TenPercentOff().IsOfferApplicable(null);
        }

        [TestMethod]
        public void TenPercentOff_IsOfferApplicable_ReturnsFalse()
        {
            //arrange
            var items = new List<Item>
            {
                new Item
                {
                    Type = ItemType.Bread
                }
            };

            //act 
            var result = new TenPercentOff().IsOfferApplicable(items);

            //assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void TenPercentOff_IsOfferApplicable_ReturnsTrue()
        {
            //arrange
            var items = new List<Item>
            {
                new Item
                {
                    Type = ItemType.Apple
                }
            };

            //act 
            var result = new TenPercentOff().IsOfferApplicable(items);

            //assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TenPercentOff_Discount_ReturnsCorrectDiscount()
        {
            //arrange
            var items = new List<Item>
            {
                new Item
                {
                    Type = ItemType.Apple,
                    Price = 1m
                },
                new Item
                {
                    Type = ItemType.Apple,
                    Price = 1m
                }
            };

            //act 
            var result = new TenPercentOff().Discount(items);

            //assert
            Assert.AreEqual(0.2m, result);
        }
    }
}
