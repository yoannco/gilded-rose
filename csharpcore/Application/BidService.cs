using Application.Interfaces;
using GildedRose;

namespace Application;

public class BidService : IBidService
{
    public int Counter { get; set; }
    public Item Item { get; set; }
    public float Price { get; set; }
    private ShopService _ShopService { get; set; }
    
    public BidService(ShopService shopService)
    {
        _ShopService = shopService;
    }
    
    public bool PriceBetterThan10Percent(float price)
    {
        return Price * 1.1 < price;
    }
    
    public void AddBid(float price)
    {
        if (PriceBetterThan10Percent(price))
        {
            Price = price;
            Counter++;
        }
        else
        {
            throw new InvalidOperationException();
        }
        
        if (Counter == 3)
        {
            Item.Price = Price;
            _ShopService.SellItem(Item.Name);
        }
    }
    
    public void CreateBid(string name, float startPrice)
    {
        var item = _ShopService.Items.FindLast(x => x.Name == name) ?? throw new InvalidOperationException();
        
        Counter = 0;
        Item = item;
        Price = startPrice;
    }
}