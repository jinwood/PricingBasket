﻿using PricingBasket.Objects;
using System.Collections.Generic;

namespace PricingBasket.Interfaces
{
    public interface IOfferLogic
    {
        bool IsOfferApplicable(List<Item> items);
        decimal Discount(List<Item> items);

        string Description { get; }
    }
}
