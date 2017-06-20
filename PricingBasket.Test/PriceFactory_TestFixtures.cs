using Microsoft.VisualStudio.TestTools.UnitTesting;
using PricingBasket.Factories;
using PricingBasket.Objects;
using System.Collections.Generic;
using System.Linq;

namespace PricingBasket.Test
{
    [TestClass]
    public class PriceFactory_TestFixtures
    {
        [TestMethod]
        public void PriceFactory_SetItemPrices_ReturnsCorrectPrice()
        {
            //arrange
            var items = new List<Item>
            {
                new Item
                {
                    Type = ItemType.Apple
                }
            };
            var priceFactory = new PriceFactory();

            //act
            priceFactory.SetItemPrices(items);

            //assert
            Assert.AreEqual(1.00m, items.FirstOrDefault().Price);
        }

        [TestMethod]
        public void PriceFactory_SetItemPrices_ReturnsNull()
        {
            //arrange
            List<Item> items = null;
            var priceFactory = new PriceFactory();

            //act
            priceFactory.SetItemPrices(items);

            //assert
            Assert.AreEqual(null, items);
        }
    }
}
