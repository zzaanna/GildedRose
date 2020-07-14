namespace csharp
{
    public class Conjured
    {
        public int NewQuality(Item item)
        {
            if (item.Quality <= 0)
                return item.Quality;

            if (item.SellIn > 0)
                return item.Quality - 2;

            return item.Quality - 4;
        }
    }
}