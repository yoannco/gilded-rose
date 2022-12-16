using Application.Interfaces;
using GildedRose;

namespace Application
{
    public class ShopService : IShopService
    {
        public List<Item> Items { get; set; }
        private readonly IItemRepository _mongoItemsRepository;
        private readonly INotifyService _notifyService;
        public float Balance { get; set; } = 0;
        
        public ShopService(IItemRepository mongoDbConnection, INotifyService notifyService)
        {
            Items = mongoDbConnection.GetInventory();
            _mongoItemsRepository = mongoDbConnection;
            _notifyService = notifyService;
        }

        public void UpdateShop()
        {
            Items.ForEach(item => item.Update());
            _mongoItemsRepository.SaveInventory(Items);
        }

        public void SellItem(string name)
        {
            _mongoItemsRepository.DeleteItem(name);
            var item = Items.FindLast(x => x.Name == name) ?? throw new InvalidOperationException();
            AddGold(item.Price);
            Items.Remove(item);
            _notifyService.NotifyPhone($"Vente de l'item : {name}", "+33779826398");
        }

        private void AddGold(float price)
        {
            Balance += price;
        }
    }
}