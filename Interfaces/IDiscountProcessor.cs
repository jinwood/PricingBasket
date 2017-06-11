using PricingBasket.Objects;

namespace PricingBasket.Interfaces
{
    public interface IDiscountProcessor
    {
        Basket SetBasketDiscounts(Basket basket);
    }
}
