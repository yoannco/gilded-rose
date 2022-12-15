namespace GildedRose;

public class Sulfuras : Item
{
    public Sulfuras(string name, int sellIn, float quality, float price, bool isConjured = false) : base(name, sellIn, quality, price,
        isConjured)
    {
    }

    protected override void ChangeQuality(float value)
    {
        _quality = 80;
    }
}