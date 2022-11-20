namespace GildedRose;

public class BackstagePasse : Item
{
    public BackstagePasse(string name, int sellIn, float quality, bool isConjured) : base(name, sellIn, quality, isConjured)
    {
    }

    protected override void UpdateQuality()
    {
        switch (SellIn)
        {
            case <= 10 and > 5:
                Quality += (QualityDegradation * 2);
                break;
            case <= 5 and >0:
                Quality += (QualityDegradation * 3);
                break;
            case <=0 :
                Quality = 0;
                break;
        }
    }
}