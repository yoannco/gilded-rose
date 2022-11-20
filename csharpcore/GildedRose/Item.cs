namespace GildedRose
{
    public class Item
    {
        public string Name { get; }
        public int SellIn { get; set; }
        public float Quality { get; set; }
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

        public Item(string name, int sellIn, float quality, bool isConjured = false)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
            IsConjured = isConjured;
            VerifyQuality();
        }

        public void Update()
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
            if (Quality is < 0 or > 50)
            {
                throw new ArgumentException();
            }
        }
    }
}