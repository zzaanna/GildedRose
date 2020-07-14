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

        public int NewQualityBrie(Item item)
        {
            if (item.Quality >= 50)
                return item.Quality;
            
            return item.Quality + 1;
        }
        
        public int NewQualityRegular(Item item)
        {
            if (item.Quality <= 0)
                return item.Quality;
            
            if (item.SellIn>0)
                return item.Quality - 1;

            return item.Quality - 2;
        }
        
        public int NewQualityConjured(Item item)
        {
            if (item.Quality <= 0)
                return item.Quality;
            
            if (item.SellIn>0)
                return item.Quality - 2;

            return item.Quality - 4;
        }
        
        public int NewQualitySulfuras(Item item)
        {
            return item.Quality;
        }
        
        public int NewQualityPass(Item item)
        {
            if (item.SellIn <= 0)
                return 0;

            if (item.Quality >= 50)
                return item.Quality;

            if (item.SellIn <= 5)
                return item.Quality + 3;
            
            if (item.SellIn <= 10)
                return item.Quality + 2;
            
            return item.Quality + 1;
        }
        
        public int NewQuality(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return item.Quality;

            if (item.Name == "Aged Brie")
                return NewQualityBrie(item);
            
            if (item.Name == "Sulfuras")
                return NewQualitySulfuras(item);
            
            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                return NewQualityPass(item);
            
            if (item.Name == "Conjured")
                return NewQualityConjured(item);

            // other regular items
            return NewQualityRegular(item);
            
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

