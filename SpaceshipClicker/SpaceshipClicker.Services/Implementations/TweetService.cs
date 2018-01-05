namespace SpaceshipClicker.Services.Implementations
{
    using Data;

    public class TweetService : ITweetService
    {
        private readonly SpaceshipClickerDbContext _db;

        public TweetService(SpaceshipClickerDbContext db)
        {
            this._db = db;
        }
    }
}