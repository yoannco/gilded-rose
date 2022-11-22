using GildedRose;

var mongoDbConnection =
    new MongoItemsRepository("mongodb+srv://admin:EpsiTomWallyn@cluster0.uwwcl.mongodb.net/?retryWrites=true&w=majority");

var shop = new Shop(mongoDbConnection);
var console = new ConsoleUI(shop);
console.DisplayBalance();