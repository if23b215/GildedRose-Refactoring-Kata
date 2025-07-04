﻿using System.Collections.Generic;
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

    [Test]
    public void Item_Quality_Decrements_By_Two_After_SellIn_Date()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(8), "Item quality should decrease by 2 after SellIn date.");
    }

    [Test]
    public void Item_Quality_Never_Negative()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 0 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(0), "Item quality should never be negative.");
    }

    [Test]
    public void AgedBrie_QualityIncreasesByOneBeforeSellByDate()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(11), "Aged Brie quality should increase by 1 before SellIn date.");
    }

    [Test]
    public void AgedBrie_QualityIncreasesTwiceAfterSellByDate()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(12), "Aged Brie quality should increase by 2 once SellIn has passed.");
        Assert.That(items[0].SellIn, Is.EqualTo(-1), "SellIn should decrement by 1.");
    }

    [Test]
    public void AgedBrie_QualityDoesNotExceedFiftyBeforeSellByDate()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(50), "Aged Brie quality should never exceed 50.");
        Assert.That(items[0].SellIn, Is.EqualTo(4), "SellIn should decrement by 1.");
    }

    [Test]
    public void Sulfuras_SellIn_And_Quality_Remain_Unchanged()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].SellIn, Is.EqualTo(10), "Sulfuras SellIn should remain unchanged.");
        Assert.That(items[0].Quality, Is.EqualTo(80), "Sulfuras quality should remain constant.");
    }

    [Test]
    public void BackstagePasses_Quality_Increases_By_One_When_SellIn_Greater_ThanTen()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(21), "Backstage passes quality should increase by 1 when SellIn > 10.");
        Assert.That(items[0].SellIn, Is.EqualTo(14), "SellIn should decrement by 1.");
    }

    [Test]
    public void BackstagePasses_Quality_Increases_By_Two_When_SellIn_Between_Six_And_Ten()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(22), "Backstage passes quality should increase by 2 when SellIn is 10 or less and greater than 5.");
        Assert.That(items[0].SellIn, Is.EqualTo(9), "SellIn should decrement by 1.");
    }

    [Test]
    public void BackstagePasses_Quality_Increases_By_Three_When_SellIn_Between_One_And_Five()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(23), "Backstage passes quality should increase by 3 when SellIn is 5 or less and greater than 0.");
        Assert.That(items[0].SellIn, Is.EqualTo(4), "SellIn should decrement by 1.");
    }

    [Test]
    public void BackstagePasses_QualityDropsToZeroAfterSellByDate()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(0), "Backstage passes quality should drop to 0 after the concert.");
        Assert.That(items[0].SellIn, Is.EqualTo(-1), "SellIn should decrement by 1.");
    }

}