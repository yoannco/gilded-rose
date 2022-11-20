namespace GildedRose;

public class Sulfuras : Item
{
    public Sulfuras(string name, int sellIn, float quality, bool isConjured) : base(name, sellIn, quality, isConjured)
    {
    }

    protected override void VerifyQuality()
    {
        Quality = 80;
    }
}