namespace GildedRose
{
    public class Shop
    {
        public List<Item> Items { get; private set; }
        public MongoDbService MongoDbConnection;
        
        public Shop(MongoDbService mongoDbConnection)
        {
            Items = mongoDbConnection.GetInventory();
            MongoDbConnection = mongoDbConnection;
        }

        public Shop(List<Item> items)
        {
            Items = items;
        }

        public void UpdateShop()
        {
            Items.ForEach(item => item.Update());
            MongoDbConnection.SaveInventory(Items);
        }
        
        public void SellIn(string name)
        {
            MongoDbConnection.DeleteItem(name);
            Items.Remove(Items.FindLast(x => x.Name == name) ?? throw new InvalidOperationException());
        }
    }
}