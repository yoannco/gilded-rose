using System.Collections;

namespace GildedRose
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int SellIn { get; protected set; }
        protected float _quality;
        public float Quality
        {
            get => _quality;
            set => ChangeQuality(value);
        }
        public bool IsConjured { get; set; }

        protected Item(string name, int sellIn, float quality, bool isConjured = false)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            IsConjured = isConjured;
        }

        public void Update()
        {
            UpdateSellIn();
            UpdateQuality();
        }

        protected void UpdateSellIn()
        {
            SellIn -= 1;
        }

        protected virtual void UpdateQuality()
        {
            
            Quality -= GetQualityDegradation();
        }

        protected float GetQualityDegradation()
        {
            var qualityDegradation = 1;
            if (SellIn < 0)
                qualityDegradation *= 2;
            if (IsConjured)
                qualityDegradation *= 2;
            return qualityDegradation;
        }

        protected virtual void ChangeQuality(float value)
        {
            _quality = value switch
            {
                < 0 => 0,
                > 50 => 50,
                _ => value
            };
        }
    }
}