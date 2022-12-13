using Application.Interfaces;
using GildedRose;

namespace Application
{
    public class ShopService : IShopService
    {
        public List<Item> Items { get; set; }
        private readonly IItemRepository _mongoItemsRepository;
        public float Balance { get; set; } = 0;
        
        public ShopService(IItemRepository mongoDbConnection)
        {
            Items = mongoDbConnection.GetInventory();
            _mongoItemsRepository = mongoDbConnection;
        }

        public void UpdateShop()
        {
            Items.ForEach(item => item.Update());
            _mongoItemsRepository.SaveInventory(Items);
        }

        public void SellItem(string name)
        {
            _mongoItemsRepository.DeleteItem(name);
            Items.Remove(Items.FindLast(x => x.Name == name) ?? throw new InvalidOperationException());
        }
    }
}