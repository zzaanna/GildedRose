using System;

namespace csharp
{
    public class BackstagePass
    {
        public int NewQuality(Item item)
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
    }
}