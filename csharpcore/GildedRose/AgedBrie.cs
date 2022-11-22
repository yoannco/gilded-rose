namespace GildedRose;

public class AgedBrie : Item
{
    public AgedBrie(string name, int sellIn, float quality, float price, bool isConjured = false) : base(name, sellIn, quality, price,
        isConjured)
    {
    }

    protected override void UpdateQuality()
    {
        Quality += GetQualityDegradation();
    }
}