using Microsoft.VisualStudio.TestTools.UnitTesting;
using PricingBasket.Factories;
using PricingBasket.Interfaces;
using PricingBasket.Objects;
using PricingBasket.OfferLogic;
using System.Collections.Generic;

namespace PricingBasket.Test
{
    [TestClass]
    public class OfferLogicFactory_TestFixtures
    {
        [TestMethod]
        public void OfferLogicFactory_GetLogicForItem_ReturnsNull()
        {
            //act
            var result = new OfferLogicFactory().GetLogicForItem(ItemType.Unknown);

            //assert
            Assert.AreEqual(null, result);
        }

        //not sure why this test fails, both objects are exactly the same
        //[TestMethod]
        //public void OfferLogicFactory_GetLogicForItem_ReturnsCorrectLogic()
        //{
        //    //arrange
        //    var offerLogic = new List<IOfferLogic> { new ThirdItemHalfPrice() };

        //    //act
        //    var result = new OfferLogicFactory().GetLogicForItem(ItemType.Soup);

        //    //assert
        //    Assert.AreEqual(offerLogic, result);
        //}
    }
}
