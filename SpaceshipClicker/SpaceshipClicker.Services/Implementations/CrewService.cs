namespace SpaceshipClicker.Services.Implementations
{
    using Data;

    public class CrewService : ICrewService
    {
        private readonly SpaceshipClickerDbContext _db;

        public CrewService(SpaceshipClickerDbContext db)
        {
            this._db = db;
        }
    }
}