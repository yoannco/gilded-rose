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

    public void Menu()
    {
        Console.WriteLine(@"
1: Afficher l'inventaire
2: Afficher la balance
3: Vendre un item
4: Mettre à jour l'inventaire");

        // await input and switch on result
        switch (Console.ReadLine())
        {
            case "1":
                DisplayInventory();
                break;
            case "2":
                DisplayBalance();
                break;
            case "3":
                SellItem();
                break;
            case "4":
                UpdateInventory();
                break;
            default:
                Console.WriteLine("Commande inconnue");
                break;
        }
    }

    private void DisplayBalance()
    {
        Console.WriteLine($"Balance : {ShopService.Balance} €");
    }

    private void UpdateInventory()
    {
        ShopService.UpdateShop();
        Console.WriteLine("Inventaire mis à jour");
    }
    
    private void SellItem()
    {
        Console.WriteLine("Nom de l'item :");
        var name = Console.ReadLine();
        ShopService.SellItem(name);
    }
}