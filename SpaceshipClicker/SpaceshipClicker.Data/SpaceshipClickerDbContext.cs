namespace SpaceshipClicker.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class SpaceshipClickerDbContext : IdentityDbContext<User>
    {
        public SpaceshipClickerDbContext(DbContextOptions<SpaceshipClickerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}