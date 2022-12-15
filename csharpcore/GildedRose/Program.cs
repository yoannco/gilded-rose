using Application;
using GildedRose;
using Service.service;

var mongoDbConnection =
    new MongoItemsRepository("mongodb+srv://admin:EpsiTomWallyn@cluster0.uwwcl.mongodb.net/?retryWrites=true&w=majority");

var shop = new ShopService(mongoDbConnection);
var console = new ConsoleUI(shop);
console.DisplayBalance();