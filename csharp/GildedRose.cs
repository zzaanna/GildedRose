using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private int NewQuality(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return item.Quality;

            if (item.Name == "Aged Brie")
            {
                var brie = new Brie();
                return brie.NewQuality(item);
            }

            if (item.Name == "Sulfuras")
            {
                var sulfuras = new Sulfuras();
                return sulfuras.NewQuality(item);
            }

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                var backstagePass = new BackstagePass();
                return backstagePass.NewQuality(item);
            }
            
            if (item.Name.IndexOf("Conjured") == 0)
            {
                var conjured = new Conjured();
                return conjured.NewQuality(item);
            }

            // other regular items
            var regular = new Regular();
            return regular.NewQuality(item);
        }

        public int NewSellIn(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return item.SellIn;
            return item.SellIn - 1;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].Quality = NewQuality(Items[i]);
                Items[i].SellIn = NewSellIn(Items[i]);
            }
        }
    }
}
