namespace SpaceshipClicker.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models.Users;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly SpaceshipClickerDbContext _db;

        public UserService(SpaceshipClickerDbContext db)
        {
            this._db = db;
        }

        public int Total { get; set; }

        public async Task<IEnumerable<UserListingModel>> GetAllAsync(int page, int pageSize)
        {
            this.Total = this._db.Users.Count();

            return await this._db.Users
                  .OrderBy(u => u.UserName)
                  .Skip((page - 1) * pageSize)
                  .Take(pageSize)
                  .ProjectTo<UserListingModel>()
                  .ToListAsync();
        }

        public async Task<IEnumerable<UserListingModel>> GetAllMatchesAsync(string searchStr, int page, int pageSize)
        {
            var users = this._db.Users
                  .Where(u => u.UserName.Contains(searchStr))
                  .OrderBy(u => u.UserName);

            this.Total = users.Count();

            return await users
                  .Skip((page - 1) * pageSize)
                  .Take(pageSize)
                  .ProjectTo<UserListingModel>()
                  .ToListAsync();
        }

        public async Task<UserDetailsModel> GetByIdAsync(string id)
            => await this._db.Users
                .Where(u => u.Id == id)
                .ProjectTo<UserDetailsModel>()
                .FirstOrDefaultAsync();
    }
}