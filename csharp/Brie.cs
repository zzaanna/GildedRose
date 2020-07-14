namespace csharp
{
    public class Brie
    {
        public int NewQuality(Item item)
        {
            if (item.Quality >= 50)
                return item.Quality;

            if (item.SellIn>0)
                return item.Quality + 1;

            return item.Quality + 2;
        }
    }
}