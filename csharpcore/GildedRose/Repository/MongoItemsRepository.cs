using MongoDB.Bson;
using MongoDB.Driver;

namespace GildedRose;

public class MongoItemsRepository : IItemRepository
{
    private IMongoDatabase MongoClient { get; }

    public MongoItemsRepository(string connectUri)
    {
        MongoClient cluster = new MongoClient(connectUri);
        MongoClient = cluster.GetDatabase("gilded_rose");
    }

    public List<Item> GetInventory()
    {
        var items = new List<Item>();
        var collection = MongoClient.GetCollection<ItemDto>("items");
        foreach (var itemDto in collection.Find(_ => true).ToListAsync().Result)
        {
            items.Add(ParseItemByType(itemDto));
        }
        return items;
    }

    public Item FindItem(string name)
    {
        var collection = MongoClient.GetCollection<ItemDto>("items");
        return ParseItemByType(collection.Find($"{{ Name: '{name}' }}").SingleAsync().Result);
    }
    
    public void SaveInventory(List<Item> items)
    {
        var collection = MongoClient.GetCollection<ItemDto>("items");
        
        items.ForEach(item =>
        {
            var filter = Builders<ItemDto>.Filter.Eq(x => x.Name, item.Name);
            var update = Builders<ItemDto>.Update.Set(x => x.SellIn, item.SellIn)
                .Set(x => x.Quality, item.Quality);
            collection.UpdateOne(filter, update);
        });
    }
    
    public void DeleteItem(string name)
    {
        var collection = MongoClient.GetCollection<ItemDto>("items");
        var deleteFilter = Builders<ItemDto>.Filter.Eq("Name", name);
        collection.DeleteOne(deleteFilter);
    }

    protected Item ParseItemByType(ItemDto itemDto)
    {
        return itemDto.Type switch
        {
            "AgedBries" => new AgedBrie(itemDto.Name, itemDto.SellIn, itemDto.Quality, itemDto.Price, itemDto.IsConjured),
            "Sulfuras" => new Sulfuras(itemDto.Name, itemDto.SellIn, itemDto.Quality, itemDto.Price, itemDto.IsConjured),
            "BackstagePass" => new BackstagePass(itemDto.Name, itemDto.SellIn, itemDto.Quality, itemDto.Price, itemDto.IsConjured),
            _ => new GenericItem(itemDto.Name, itemDto.SellIn, itemDto.Quality, itemDto.Price, itemDto.IsConjured)
            };
    }
}