namespace GildedRose
{
    public class Shop
    {
        private List<Item> Items { get; set; }
        
        public Shop(List<Item> items)
        {
            Items = items;
        }

        public Shop()
        {
            Items = new List<Item>();
        }

        public void UpdateShop()
        {
            Items.ForEach(item => item.Update());
        }
    }
}