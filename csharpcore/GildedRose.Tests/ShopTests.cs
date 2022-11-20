namespace GildedRose.Tests;

public class ShopTests
{
    private Item _item;
    private Item _sellInOverrunItem;
    private Item _conjuredItem;
    private Item _conjuredSellInOverrunItem;
    private Item _overQualityItem;
    private Item _sulfuras;
    private Item _conjuredSulfuras;
    private Item _backstagePass;
    private Item _conguredBackstagePass;
    private Item _overSellInBackstagePass;
    private Item _sellInLessThan5BackstagePass;
    private Item _sellInLessThan10BackstagePass;
    private Item _agedBrie;
    private Item _conjuredAgedBrie;
    private Item _overQualityAgedBrie;


    [SetUp]
    public void Setup()
    {
        _item = new("item", 30, 30);
        _sellInOverrunItem = new("item", -1, 30);
        _conjuredItem = new("conjuredItem", 30, 30, true);
        _conjuredSellInOverrunItem = new("conjuredItem", -1, 30, true);
        _overQualityItem = new("item", 30, 0);
        _sulfuras = new Sulfuras("sulfuras", 30, 30);
        _conjuredSulfuras = new Sulfuras("conjuredSulfuras", 30, 30, true);
        _backstagePass = new BackstagePass("backstagePass", 30, 30);
        _conguredBackstagePass = new BackstagePass("conguredBackstagePass", 30, 30, true);
        _overSellInBackstagePass = new BackstagePass("conguredBackstagePass", -1, 30);
        _sellInLessThan5BackstagePass = new BackstagePass("conguredBackstagePass", 4, 30);
        _sellInLessThan10BackstagePass = new BackstagePass("conguredBackstagePass", 9, 30);
        _agedBrie = new AgedBrie("agedBrie", 30, 30);
        _conjuredAgedBrie = new AgedBrie("conjuredAgedBrie", 30, 30, true);
        _overQualityAgedBrie = new AgedBrie("item", 30, 50);
    }

    [Test]
    public void Should_Build()
    {
        new Shop(new List<Item>());
    }

    [Test]
    public void UpdateShopOnItemsTest()
    {
        var items = new List<Item>
        {
            _item,
            _conjuredItem,
        };
        var shop = new Shop(items);
        shop.UpdateShop();

        foreach (var item in shop.Items)
        {
            if (item.IsConjured)
                Assert.That(item.Quality, Is.EqualTo(28));
            else
                Assert.That(item.Quality, Is.EqualTo(29));

            Assert.That(item.SellIn, Is.EqualTo(29));
        }
    }
    
    [Test]
    public void UpdateShopOnItemsWithSellInOverrunTest()
    {
        var items = new List<Item>
        {
            _sellInOverrunItem,
            _conjuredSellInOverrunItem,
        };
        var shop = new Shop(items);
        shop.UpdateShop();

        foreach (var item in shop.Items)
        {
            if (item.IsConjured)
                Assert.That(item.Quality, Is.EqualTo(26));
            else
                Assert.That(item.Quality, Is.EqualTo(28));
        }
    }

    [Test]
    public void UpdateShopOnItemsWithQualityOverrunTest()
    {
        var items = new List<Item>
        {
            _overQualityItem,
        };
        var shop = new Shop(items);
        shop.UpdateShop();

        Assert.That(shop.Items[0].Quality, Is.EqualTo(0));
    }


    [Test]
    public void UpdateShopOnSulfurasItemsTest()
    {
        var items = new List<Item>
        {
            _sulfuras,
            _conjuredSulfuras,
        };
        var shop = new Shop(items);
        shop.UpdateShop();

        foreach (var item in shop.Items)
        {
            if (item.IsConjured)
                Assert.That(item.Quality, Is.EqualTo(80));
            else
                Assert.That(item.Quality, Is.EqualTo(80));
        }
    }

    [Test]
    public void UpdateShopOnAgedBrieItemsTest()
    {
        var items = new List<Item>
        {
            _agedBrie,
            _conjuredAgedBrie,
        };
        var shop = new Shop(items);
        shop.UpdateShop();

        foreach (var item in shop.Items)
        {
            if (item.IsConjured)
                Assert.That(item.Quality, Is.EqualTo(32));
            else
                Assert.That(item.Quality, Is.EqualTo(31));
        }
    }
    
    [Test]
    public void UpdateShopOnAgedBrieWithQualityOverrunTest()
    {
        var items = new List<Item>
        {
            _overQualityAgedBrie,
        };
        var shop = new Shop(items);
        shop.UpdateShop();

        Assert.That(shop.Items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void UpdateShopOnBackstagePassItemsTest()
    {
        var items = new List<Item>
        {
            _backstagePass,
            _conguredBackstagePass,
        };
        var shop = new Shop(items);
        shop.UpdateShop();

        foreach (var item in shop.Items)
        {
            if (item.IsConjured)
                Assert.That(item.Quality, Is.EqualTo(32));
            else
                Assert.That(item.Quality, Is.EqualTo(31));
        }
    }

    [Test]
    public void UpdateShopOnBackstagePassWithSellInOverrunTest()
    {
        var items = new List<Item>
        {
            _overSellInBackstagePass
        };
        var shop = new Shop(items);
        shop.UpdateShop();

        Assert.That(shop.Items[0].Quality, Is.EqualTo(0));
    }
    
    [Test]
    public void UpdateShopOnBackstagePassWithSellInLessThan5Test()
    {
        var items = new List<Item>
        {
            _sellInLessThan5BackstagePass
        };
        var shop = new Shop(items);
        shop.UpdateShop();

        Assert.That(shop.Items[0].Quality, Is.EqualTo(33));
    }
    
    [Test]
    public void UpdateShopOnBackstagePassWithSellInLessThan10Test()
    {
        var items = new List<Item>
        {
            _sellInLessThan10BackstagePass
        };
        var shop = new Shop(items);
        shop.UpdateShop();

        Assert.That(shop.Items[0].Quality, Is.EqualTo(32));
    }
    
}