namespace GildedRose;

public class AgedBrie : Item
{
    public AgedBrie(string name, int sellIn, float quality, bool isConjured = false) : base(name, sellIn, quality,
        isConjured)
    {
    }

    protected override void UpdateQuality()
    {
        Quality += GetQualityDegradation();
    }
}