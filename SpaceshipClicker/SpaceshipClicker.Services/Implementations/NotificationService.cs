namespace SpaceshipClicker.Services.Implementations
{
    using Data;

    public class NotificationService : INotificationService
    {
        private readonly SpaceshipClickerDbContext _db;

        public NotificationService(SpaceshipClickerDbContext db)
        {
            this._db = db;
        }
    }
}