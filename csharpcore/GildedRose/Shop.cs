namespace GildedRose
{
    public class Shop
    {
        public List<Item> Items { get; set; }
        private readonly IItemRepository _mongoItemsRepository;

        public Shop(IItemRepository mongoItemsRepository)
        {
            _mongoItemsRepository = mongoItemsRepository;
            Items = _mongoItemsRepository.GetInventory();
        }

        public void UpdateShop()
        {
            Items.ForEach(item => item.Update());
            _mongoItemsRepository.SaveInventory(Items);
        }

        public void SellIn(string name)
        {
            _mongoItemsRepository.DeleteItem(name);
            Items.Remove(Items.FindLast(x => x.Name == name) ?? throw new InvalidOperationException());
        }
    }
}