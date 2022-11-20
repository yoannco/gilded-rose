namespace GildedRose
{
    public class Shop
    {
        public List<Item> Items { get; private set; }
        
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