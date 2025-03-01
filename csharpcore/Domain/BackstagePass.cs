﻿namespace GildedRose;

public class BackstagePass : Item
{
    public BackstagePass(string name, int sellIn, float quality, float price, bool isConjured = false) : base(name, sellIn, quality, price,
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