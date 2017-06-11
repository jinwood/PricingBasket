using System;
using System.Collections.Generic;
using PricingBasket.Interfaces;
using PricingBasket.Objects;

namespace PricingBasket
{
    //this class maps our space delimited string list of items 
    //into a List of type Item
    public class ItemMapper : IItemMapper
    {
        public List<Item> MapStringToItemList(string items)
        {
            var itemArr = items.Split(' ');
            var mappedItems = new List<Item>();

            foreach (var item in itemArr)
            {
                //catch any odd upper / lower case
                var normalized = item.ToLower();
                normalized = Char.ToUpper(normalized[0]) + normalized.Substring(1);

                try
                {
                    var newItemType = (ItemType)Enum.Parse(typeof(ItemType), normalized);
                    mappedItems.Add(new Item
                    {
                        Type = newItemType
                    });
                }
                catch (Exception)
                {
                    Console.WriteLine($"Unknown item - {normalized}");
                    //do some logging
                }
            }
            return mappedItems;
        }
    }
}
