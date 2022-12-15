namespace GildedRose
{
    public class Shop
    {
        public List<Item> Items { get; set; }
        private readonly IItemRepository _mongoItemsRepository;
        private readonly NotifyService _notifyService;
        public float Balance { get; set; } = 0;
        
        public Shop(IItemRepository mongoDbConnection)
        {
            Items = mongoDbConnection.GetInventory();
            _mongoItemsRepository = mongoDbConnection;
            _notifyService = new NotifyService();
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
            _notifyService.NotifyWhatsapp($"Vente de l'item : {name}", "+33779826398");
        }
    }
}