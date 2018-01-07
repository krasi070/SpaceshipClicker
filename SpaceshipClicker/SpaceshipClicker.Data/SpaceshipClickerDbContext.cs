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

        public DbSet<Crewmate> Crew { get; set; }

        public DbSet<CrewmateName> CrewmateNames { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<BottleMessage> BottleMessages { get; set; }

        public DbSet<Tweet> Tweets { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(u => u.Review)
                .WithOne(r => r.User)
                .HasForeignKey<Review>(r => r.UserId);

            builder.Entity<BottleMessage>()
                .HasOne(bm => bm.User)
                .WithMany(u => u.BottleMessages)
                .HasForeignKey(bm => bm.UserId);

            builder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            builder.Entity<Crewmate>()
                .HasOne(c => c.User)
                .WithMany(u => u.Crew)
                .HasForeignKey(c => c.UserId);

            base.OnModelCreating(builder);
        }
    }
}