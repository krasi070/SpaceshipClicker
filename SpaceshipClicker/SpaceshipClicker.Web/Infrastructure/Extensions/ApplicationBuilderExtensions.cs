namespace SpaceshipClicker.Web.Infrastructure.Extensions
{
    using Constants;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SpaceshipClicker.Data;
    using SpaceshipClicker.Data.Models;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<SpaceshipClickerDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                    {
                        var adminName = GlobalConstants.AdministratorRole;
                        var roleExists = await roleManager.RoleExistsAsync(adminName);
                        if (!roleExists)
                        {
                            await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = adminName
                            });
                        }

                        var adminEmail = "admin@mysite.com";
                        var adminUser = await userManager.FindByEmailAsync(adminEmail);
                        if (adminUser == null)
                        {
                            adminUser = new User
                            {
                                Email = adminEmail,
                                UserName = "admin"
                            };

                            await userManager.CreateAsync(adminUser, "admin1&2&3");
                            await userManager.AddToRoleAsync(adminUser, adminName);
                        }
                    })
                    .Wait();
            }

            return app;
        }
    }
}