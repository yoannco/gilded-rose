using GildedRose;

var mongoDbConnection =
    new MongoItemsRepository("mongodb+srv://admin:EpsiTomWallyn@cluster0.uwwcl.mongodb.net/?retryWrites=true&w=majority");

var shop = new Shop(mongoDbConnection);
shop.UpdateShop();
shop.SellIn("test2");

Console.WriteLine("start!");
