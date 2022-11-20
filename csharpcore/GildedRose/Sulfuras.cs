namespace GildedRose;

public class Sulfuras : Item
{
    public Sulfuras(string name, int sellIn, float quality, bool isConjured = false) : base(name, sellIn, quality,
        isConjured)
    {
    }

    protected override void ChangeQuality(float value)
    {
        _quality = 80;
    }
}