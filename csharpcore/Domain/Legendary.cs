using GildedRose;

namespace ClassLibrary1;

public class Legendary : EquipmentItem
{
    public Legendary(string name, int sellIn, float quality, float price, int attack, int defense, bool isConjured = false) : base(name, sellIn, quality, price, attack, defense, isConjured)
    {
    }

    protected override void ChangeQuality(float value)
    {
        _quality = 80;
    }
}