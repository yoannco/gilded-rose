using GildedRose;

namespace ClassLibrary1;

public class RelicItem : Item
{
    public RelicItem(string name, int sellIn, float quality, float price, bool isConjured = false) : base(name, sellIn, quality, price, isConjured)
    {
    }
}