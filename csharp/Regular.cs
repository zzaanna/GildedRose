namespace csharp
{
    public class Regular
    {
        public int NewQuality(Item item)
        {
            if (item.Quality <= 0)
                return item.Quality;
            
            if (item.SellIn>0)
                return item.Quality - 1;

            return item.Quality - 2;
        }
    }
}