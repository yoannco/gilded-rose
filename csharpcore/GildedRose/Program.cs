using Application;
using GildedRose;
using Service.service;

var mongoDbConnection =
    new MongoItemsRepository("mongodb+srv://admin:EpsiTomWallyn@cluster0.uwwcl.mongodb.net/?retryWrites=true&w=majority");

var notificationService = new NotifyService();
var shop = new ShopService(mongoDbConnection, notificationService);
var console = new ConsoleUI(shop);
console.DisplayBalance();