namespace SpaceshipClicker.Services.Implementations
{
    using Data;
    using SpaceshipClicker.Services.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly SpaceshipClickerDbContext _db;

        public UserService(SpaceshipClickerDbContext db)
        {
            this._db = db;
        }

        public int Total { get; set; }

        public IEnumerable<UserListingModel> GetAll(int page, int pageSize)
        {
            this.Total = this._db.Users.Count();

            return this._db.Users
                  .OrderBy(u => u.UserName)
                  .Skip((page - 1) * pageSize)
                  .Take(pageSize)
                  .Select(u => new UserListingModel()
                  {
                      Id = u.Id,
                      Username = u.UserName,
                      SpaceshipName = u.SpaceshipName,
                      Stars = u.Review != null ? u.Review.Score / 2f : 0f,
                      ReviewId = u.ReviewId
                  });
        }

        public IEnumerable<UserListingModel> GetAllMatches(string searchStr, int page, int pageSize)
        {
            var users = this._db.Users
                  .Where(u => u.UserName.Contains(searchStr))
                  .OrderBy(u => u.UserName);

            this.Total = users.Count();

            return users
                  .Skip((page - 1) * pageSize)
                  .Take(pageSize)
                  .Select(u => new UserListingModel()
                  {
                      Id = u.Id,
                      Username = u.UserName,
                      SpaceshipName = u.SpaceshipName,
                      Stars = u.Review != null ? u.Review.Score / 2f : 0f,
                      ReviewId = u.ReviewId
                  });
        }

        public UserDetailsModel GetById(string id)
            => this._db.Users
                .Where(u => u.Id == id)
                .Select(u => new UserDetailsModel()
                {
                    Id = u.Id,
                    Username = u.UserName,
                    SpaceshipName = u.SpaceshipName,
                    Stars = u.Review != null ? u.Review.Score / 2f : 0f,
                    ReviewId = u.ReviewId,
                    Email = u.Email,
                    Units = u.Units,
                    UnitsPerClick = u.UnitsPerClick,
                    UnitsPerSecond = u.UnitsPerSecond,
                    AiLevel = u.AiLevel,
                    HasBathroom = u.HasBathroom,
                    HasCoffee = u.HasCoffee,
                    HasEnhancements = u.HasEnhancements,
                    Review = u.Review != null ? u.Review.Text : null,
                    ReviewedOn = u.Review != null ? u.Review.ReviewedOn : DateTime.Now
                })
                .FirstOrDefault();
    }
}