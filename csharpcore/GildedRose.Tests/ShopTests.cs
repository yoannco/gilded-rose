using Application;
using Application.Interfaces;
using Service.service;

namespace GildedRose.Tests;

public class ShopTests
{
    private ShopService _shopService;
    private IItemRepository _itemRepository;
    private INotifyService _notifyService;


    [SetUp]
    public void Setup()
    {
        _itemRepository = new InMemoryRepository();
        _shopService = new ShopService(_itemRepository, _notifyService);
    }

    [Test]
    public void UpdateShopOnItemsTest()
    {
        _shopService.UpdateShop();

        Assert.That(_shopService.Items.First(item => item.Name == "conjuredItem").Quality, Is.EqualTo(28));
        Assert.That(_shopService.Items.First(item => item.Name == "item").Quality, Is.EqualTo(29));
        Assert.That(_shopService.Items.First(item => item.Name == "item").SellIn, Is.EqualTo(29));
    }


    [Test]
    public void UpdateShopOnItemsWithSellInOverrunTest()
    {
        _shopService.UpdateShop();

        Assert.That(_shopService.Items.First(item => item.Name == "conjuredSellInOverrunItem").Quality, Is.EqualTo(26));
        Assert.That(_shopService.Items.First(item => item.Name == "sellInOverrunItem").Quality, Is.EqualTo(28));
    }

    [Test]
    public void UpdateShopOnItemsWithQualityOverrunTest()
    {
        _shopService.UpdateShop();

        Assert.That(_shopService.Items.First(item => item.Name == "overQualityItem").Quality, Is.EqualTo(0));
    }


    [Test]
    public void UpdateShopOnSulfurasItemsTest()
    {
        _shopService.UpdateShop();

        Assert.That(_shopService.Items.First(item => item.Name == "sulfuras").Quality, Is.EqualTo(80));
        Assert.That(_shopService.Items.First(item => item.Name == "conjuredSulfuras").Quality, Is.EqualTo(80));
    }

    [Test]
    public void UpdateShopOnAgedBrieItemsTest()
    {
        _shopService.UpdateShop();

        Assert.That(_shopService.Items.First(item => item.Name == "conjuredAgedBrie").Quality, Is.EqualTo(32));
        Assert.That(_shopService.Items.First(item => item.Name == "agedBrie").Quality, Is.EqualTo(31));
    }

    [Test]
    public void UpdateShopOnAgedBrieWithQualityOverrunTest()
    {
        _shopService.UpdateShop();
        
        Assert.That(_shopService.Items.First(item => item.Name == "overQualityAgedBrie").Quality, Is.EqualTo(50));
    }

    [Test]
    public void UpdateShopOnBackstagePassItemsTest()
    {
        _shopService.UpdateShop();

        Assert.That(_shopService.Items.First(item => item.Name == "conguredBackstagePass").Quality, Is.EqualTo(32));
        Assert.That(_shopService.Items.First(item => item.Name == "backstagePass").Quality, Is.EqualTo(31));
    }

    [Test]
    public void UpdateShopOnBackstagePassWithSellInOverrunTest()
    {
        _shopService.UpdateShop();

        Assert.That(_shopService.Items.First(item => item.Name == "overSellInBackstagePass").Quality, Is.EqualTo(0));
    }

    [Test]
    public void UpdateShopOnBackstagePassWithSellInLessThan5Test()
    {
        _shopService.UpdateShop();

        Assert.That(_shopService.Items.First(item => item.Name == "sellInLessThan5BackstagePass").Quality, Is.EqualTo(33));
    }

    [Test]
    public void UpdateShopOnBackstagePassWithSellInLessThan10Test()
    {
        _shopService.UpdateShop();

        Assert.That(_shopService.Items.First(item => item.Name == "sellInLessThan10BackstagePass").Quality, Is.EqualTo(32));
    }
}