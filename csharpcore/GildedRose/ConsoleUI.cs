using Application;

namespace GildedRose;

public class ConsoleUI
{
    public ShopService ShopService { get; set; } 
    public ConsoleUI(ShopService shopService)
    {
        ShopService = shopService;
    }
    public void DisplayInventory()
    {
        Console.WriteLine("##### INVENTORY #####");
        foreach (var item in ShopService.Items)
        {
            Console.WriteLine($"Name : {item.Name} | Quality : {item.Quality} | SellIn : {item.SellIn}");
        }
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Balance : {ShopService.Balance} €");
    }

    public void UpdateInventory()
    {
        
    }

    public void SellItem(string type, int quality)
    {
        
    }
}