using PricingBasket.Interfaces;

namespace PricingBasket.Objects
{
    public class Offer
    {
        public OfferType OfferType { get; set; }

        public IOfferLogic OfferLogic { get; set; }
    }
}
