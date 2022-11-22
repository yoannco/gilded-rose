namespace GildedRose;

public class ConsoleUI
{
    public Shop Shop { get; set; } 
    public ConsoleUI(Shop shop)
    {
        Shop = shop;
    }
    public void DisplayInventory()
    {
        Console.WriteLine("##### INVENTORY #####");
        foreach (var item in Shop.Items)
        {
            Console.WriteLine($"Name : {item.Name} | Quality : {item.Quality} | SellIn : {item.SellIn}");
        }
    }

    public void DisplayBalance()
    {
        Console.WriteLine($"Balance : {Shop.Balance} €");
    }

    public void UpdateInventory()
    {
        
    }

    public void SellItem(string type, int quality)
    {
        
    }
}