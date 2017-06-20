using System;
using System.Collections.Generic;
using PricingBasket.Interfaces;
using PricingBasket.Objects;
using System.Globalization;
using System.Linq;

namespace PricingBasket
{
    //this class maps our space delimited string list of items 
    //into a List of type Item
    public class ItemMapper : IItemMapper
    {
        public List<Item> MapStringToItemList(string items)
        {
            if (string.IsNullOrEmpty(items)) return null;

            var itemArr = items.Split(' ');
            var mappedItems = new List<Item>();

            foreach (var item in itemArr)
            {
                bool parsed = false;
                ItemType newItemType;
                parsed = Enum.TryParse(item, true, out newItemType);

                mappedItems.Add(new Item
                {
                    Type = newItemType
                });

                if (!parsed) Console.WriteLine($"Unknown item - {item}");
            }
            return mappedItems;
        }
    }
}
