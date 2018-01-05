namespace SpaceshipClicker.Services.Implementations
{
    using Data;

    public class BottleMessageService : IBottleMessageService
    {
        private readonly SpaceshipClickerDbContext _db;

        public BottleMessageService(SpaceshipClickerDbContext db)
        {
            this._db = db;
        }
    }
}