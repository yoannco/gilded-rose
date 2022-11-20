namespace GildedRose;

public class BackstagePasse : Item
{
    public BackstagePasse(string name, int sellIn, float quality, bool isConjured = false) : base(name, sellIn, quality,
        isConjured)
    {
    }

    protected override void UpdateQuality()
    {
        switch (SellIn)
        {
            case <= 10 and > 5:
                Quality += (GetQualityDegradation() * 2);
                break;
            case <= 5 and > 0:
                Quality += (GetQualityDegradation() * 3);
                break;
            case <= 0:
                Quality = 0;
                break;
            default:
                Quality += GetQualityDegradation();
                break;
        }
    }
}