using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void Foo()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Name, Is.EqualTo("foo"));
    }

    [Test]
    public void Item_Quality_Decrements_By_One()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(9), "Item Quality should decrease by 1 each day.");
    }

    [Test]
    public void Item_SellIn_Decrements_By_One()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].SellIn, Is.EqualTo(4), "Item SellIn should decrease by 1 each day.");
    }
}