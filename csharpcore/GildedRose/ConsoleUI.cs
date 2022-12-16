using Application;

namespace GildedRose;

public class ConsoleUI
{
    public ShopService ShopService { get; set; } 
    public BidService BidService { get; set; }
    public ConsoleUI(ShopService shopService, BidService bidService)
    {
        ShopService = shopService;
        BidService = bidService;
    }
    public void DisplayInventory()
    {
        Console.WriteLine("##### INVENTORY #####");
        foreach (var item in ShopService.Items)
        {
            Console.WriteLine($"Name : {item.Name} | Quality : {item.Quality} | SellIn : {item.SellIn} | Price : {item.Price}");
        }
    }

    public void Menu()
    {
        Console.WriteLine(@"
1: Afficher l'inventaire
2: Afficher la balance
3: Vendre un item
4: Mettre à jour l'inventaire
5: Créer une enchère");

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
            case "5":
                CreateBid();
                break;
            default:
                Console.WriteLine("Commande inconnue");
                break;
        }
    }

    private void DisplayBalance()
    {
        Console.WriteLine($"Balance : {ShopService.Balance} Golds");
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
    
    private void CreateBid()
    {
        Console.WriteLine("Nom de l'item :");
        var name = Console.ReadLine();
        Console.WriteLine("Prix depart de l'enchère :");
        var startPrice = int.Parse(Console.ReadLine());
        try
        {
            BidService.CreateBid(name, startPrice);
        }
        catch (Exception e)
        {
            Console.WriteLine("Produit invalide");
            return;
        }
        Console.Clear();

        while (BidService.Counter < 3)
        {
            Console.WriteLine("Prix de l'enchère :");
            var price = float.Parse(Console.ReadLine());
            try
            {
                BidService.AddBid(price);
                Console.WriteLine($"L'enchère est maintenant de {BidService.Price} Golds");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Prix invalide, l'enchère doit être supérieure à 10% du prix actuelle ({BidService.Price * 1.1} Golds)");
            }
        }
        
        Console.WriteLine(@$"L'enchère est terminée ! Article vendu au prix de {BidService.Price} Golds
Solde de la boutique : {ShopService.Balance} Golds");
        Console.ReadKey();
        Console.Clear();
    }
}