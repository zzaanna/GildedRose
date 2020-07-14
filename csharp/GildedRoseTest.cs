using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void TestRegularDegrade()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Regular", SellIn = 8, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(19, Items[0].Quality);
            Assert.AreEqual(7, Items[0].SellIn);

            Items[0].SellIn = 0;
            app.UpdateQuality();
            Assert.AreEqual(17, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(15, Items[0].Quality);
        }
        
        [Test]
        public void TestConjured()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Something", SellIn = 8, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(18, Items[0].Quality);
            Assert.AreEqual(7, Items[0].SellIn);

            Items[0].SellIn = 0;
            app.UpdateQuality();
            Assert.AreEqual(14, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(10, Items[0].Quality);
        }
        
        [Test]
        public void TestQualityNeverNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Regular", SellIn = 8, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
        
        [Test]
        public void TestAgedBrie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 8, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(11, Items[0].Quality);
        }
        
        [Test]
        public void TestAgedBrieNotExceed50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 8, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }
        
        [Test]
        public void TestSulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 8, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
            Assert.AreEqual(8, Items[0].SellIn);
        }
        
        [Test]
        public void TestBackstagePass()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(11, Items[0].Quality);

            Items[0].SellIn = 10;
            app.UpdateQuality();
            Assert.AreEqual(13, Items[0].Quality);
            
            Items[0].SellIn = 5;
            app.UpdateQuality();
            Assert.AreEqual(16, Items[0].Quality);
            
            Items[0].SellIn = 0;
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }
        
    }
}
