using System.Collections;

namespace GildedRose
{
    public class GenericItem : Item
    {
        public GenericItem(string name, int sellIn, float quality, float price, bool isConjured = false) : base(name, sellIn, quality, price, isConjured)
        {
        }
    }
}