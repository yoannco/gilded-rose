namespace GildedRose
{
    public class Item
    {
        protected string Name { get; set; }
        protected int SellIn { get; set; }
        protected float Quality { get; set; }
        private bool _IsConjured { get; set; }

        public bool IsConjured
        {
            get => _IsConjured;
            set
            {
                _IsConjured = value;
                if (value)
                {
                    QualityDegradation = 2;
                }
                else
                {
                    QualityDegradation = 1;
                }
            }
        }

        protected int QualityDegradation { get; set; } = 1;

        public Item(string name, int sellIn, float quality, bool isConjured)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            IsConjured = isConjured;
            VerifyQuality();
        }

        protected void Update()
        {
            UpdateSellIn();
            UpdateQuality();
        }

        protected void UpdateSellIn()
        {
            SellIn -= QualityDegradation;
        }

        protected virtual void UpdateQuality()
        {
            Quality -= QualityDegradation;
            VerifyQuality();
        }

        protected virtual void VerifyQuality()
        {
            Quality = Quality switch
            {
                < 0 => 0,
                > 50 => 50,
                _ => Quality
            };
        }
    }
}