using System;
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

        private int NewQualityBrie(Item item)
        {
            if (item.Quality >= 50)
                return item.Quality;

            if (item.SellIn>0)
                return item.Quality + 1;

            return item.Quality + 2;
        }

        private int NewQualityRegular(Item item)
        {
            if (item.Quality <= 0)
                return item.Quality;
            
            if (item.SellIn>0)
                return item.Quality - 1;

            return item.Quality - 2;
        }

        private int NewQualityConjured(Item item)
        {
            if (item.Quality <= 0)
                return item.Quality;
            
            if (item.SellIn>0)
                return item.Quality - 2;

            return item.Quality - 4;
        }

        private int NewQualitySulfuras(Item item)
        {
            return item.Quality;
        }

        private int NewQualityBackstagePass(Item item)
        {
            if (item.SellIn <= 0)
                return 0;

            if (item.Quality >= 50)
                return item.Quality;

            if (item.SellIn <= 5)
                return Math.Min(item.Quality + 3,50);
            
            if (item.SellIn <= 10)
                return Math.Min(item.Quality + 2,50);
            
            return item.Quality + 1;
        }

        private int NewQuality(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return item.Quality;

            if (item.Name == "Aged Brie")
                return NewQualityBrie(item);
            
            if (item.Name == "Sulfuras")
                return NewQualitySulfuras(item);
            
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                return NewQualityBackstagePass(item);
            
            if (item.Name.IndexOf("Conjured") == 0)
                return NewQualityConjured(item);

            // other regular items
            return NewQualityRegular(item);
            
        }

        private int NewSellIn(Item item)
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

