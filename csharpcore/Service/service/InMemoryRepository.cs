﻿using ClassLibrary1;
using GildedRose;

namespace Service.service;

public class InMemoryRepository : IItemRepository
{
    private List<Item> _items = new()
    {
        new GenericItem("item", 30, 30, 1, 3, 5),
        new GenericItem("conjuredItem", 30, 30, 1, 3, 5, true),
        new GenericItem("sellInOverrunItem", -1, 30, 1, 3, 5),
        new GenericItem("conjuredSellInOverrunItem", -1, 30, 1, 3, 5, true),
        new GenericItem("overQualityItem", 30, 0, 1, 3, 5),
        new Legendary("sulfuras", 30, 30, 1, 3, 5),
        new Legendary("conjuredSulfuras", 30, 30, 1, 3, 5, true),
        new BackstagePass("backstagePass", 30, 30, 1),
        new BackstagePass("conguredBackstagePass", 30, 30, 1, true),
        new BackstagePass("overSellInBackstagePass", -1, 30, 1),
        new BackstagePass("sellInLessThan5BackstagePass", 4, 30, 1),
        new BackstagePass("sellInLessThan10BackstagePass", 9, 30, 1),
        new AgedBrie("agedBrie", 30, 30, 1),
        new AgedBrie("conjuredAgedBrie", 30, 30, 1, true),
        new AgedBrie("overQualityAgedBrie", 30, 50, 1),
    };

    public List<Item> GetInventory()
    {
        return _items;
    }

    public Item FindItem(string name)
    {
        return _items.Find(item => item.Name == name) ?? throw new InvalidOperationException();
    }

    public void SaveInventory(List<Item> items)
    {
        _items = items;
    }

    public void DeleteItem(string name)
    {
        _items.Remove(_items.First(item => item.Name == name));
    }
}