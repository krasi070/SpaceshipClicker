namespace SpaceshipClicker.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SpaceshipClicker.Services.Models.Reviews;
    using System.Threading.Tasks;

    public class ReviewService : IReviewService
    {
        private readonly SpaceshipClickerDbContext _db;

        public ReviewService(SpaceshipClickerDbContext db)
        {
            this._db = db;
        }

        public int Total { get; set; }

        public async Task CreateAsync(string text, int score, string userId)
        {
            Review newReview = new Review()
            {
                Text = text,
                Score = score,
                UserId = userId,
                ReviewedOn = DateTime.Now,
                IsApproved = true
            };

            this._db.Reviews.Add(newReview);
            await this._db.SaveChangesAsync();

            var user = this._db.Users.Find(userId);
            user.ReviewId = user.Review.Id;
            await this._db.SaveChangesAsync();
        }

        public async Task ChangeStatesAsync(int id, bool approved, bool @default)
        {
            var review = await this._db.Reviews.FindAsync(id);
            if (review == null)
            {
                return;
            }

            review.IsApproved = approved;
            review.IsDefault = @default;

            await this._db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string text, int score)
        {
            var review = await this._db.Reviews.FindAsync(id);
            if (review == null)
            {
                return;
            }

            review.Text = text;
            review.Score = score;
            review.ReviewedOn = DateTime.Now;

            await this._db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var review = await this._db.Reviews.FindAsync(id);
            if (review == null)
            {
                return;
            }

            var user = await this._db.Users.FindAsync(review.UserId);
            user.ReviewId = null;
            await this._db.SaveChangesAsync();

            this._db.Reviews.Remove(review);
            await this._db.SaveChangesAsync();
        }

        public async Task<bool> HasUserPostedReviewAsync(string username)
            => await this._db.Reviews.AnyAsync(r => r.User.UserName == username);

        public async Task<ReviewAdminDetailsModel> GetByIdAsync(int id)
            => await this._db.Reviews
                .Where(r => r.Id == id)
                .ProjectTo<ReviewAdminDetailsModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<ReviewAdminDetailsModel>> GetAllWithDetailsAsync(bool approved, bool notApproved, bool @default, bool notDefault, int page = 0, int pageSize = 20)
        {
            List<ReviewAdminDetailsModel> reviews = new List<ReviewAdminDetailsModel>();
            if (approved)
            {
                reviews.AddRange(await this._db.Reviews
                    .Where(r => r.IsApproved)
                    .ProjectTo<ReviewAdminDetailsModel>()
                    .ToListAsync());
            }

            if (notApproved)
            {
                reviews.AddRange(await this._db.Reviews
                    .Where(r => !r.IsApproved)
                    .ProjectTo<ReviewAdminDetailsModel>()
                    .ToListAsync());
            }

            if (@default && !notDefault)
            {
                reviews = reviews
                    .Where(r => r.IsDefault)
                    .ToList();
            }
            else if (!@default && notDefault)
            {
                reviews = reviews
                    .Where(r => !r.IsDefault)
                    .ToList();
            }

            this.Total = reviews.Count;

            return reviews
                .OrderByDescending(r => r.ReviewedOn)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public async Task<IEnumerable<ReviewDetailsModel>> GetAllApprovedAsync(ReviewOrder order = ReviewOrder.DateDescending, int page = 0, int pageSize = 20)
        {
            IEnumerable<ReviewDetailsModel> reviews = new List<ReviewDetailsModel>();
            if (page > 0)
            {
                reviews = await this._db.Reviews
                    .Where(r => r.IsApproved)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ProjectTo<ReviewDetailsModel>()
                    .ToListAsync();
            }
            else
            {
                reviews = await this._db.Reviews
                    .Where(r => r.IsApproved)
                    .ProjectTo<ReviewDetailsModel>()
                    .ToListAsync();
            }

            switch (order)
            {
                case ReviewOrder.StarsAscending:
                    return reviews.OrderBy(r => r.Score);
                case ReviewOrder.StarsDescending:
                    return reviews.OrderByDescending(r => r.Score);
                case ReviewOrder.DateAscending:
                    return reviews.OrderBy(r => r.ReviewedOn);
                case ReviewOrder.DateDescending:
                    return reviews.OrderByDescending(r => r.ReviewedOn);
                default:
                    return reviews;
            }
        }

        public async Task<IEnumerable<ReviewDefaultModel>> GetDefaultAsync(int amount = 3)
            => await this._db.Reviews
                .Where(r => r.IsDefault)
                .OrderByDescending(r => r.ReviewedOn)
                .Take(amount)
                .ProjectTo<ReviewDefaultModel>()
                .ToListAsync();

        public async Task<IEnumerable<ReviewDetailsModel>> GetFilteredReviewsAsync(ReviewOrder order, float? minStars = null, float? maxStars = null, DateTime? from = null, DateTime? to = null)
        {
            if (minStars == null)
            {
                minStars = 0;
            }

            if (maxStars == null)
            {
                maxStars = 5;
            }

            if (from == null)
            {
                from = new DateTime(1, 1, 1);
            }

            if (to == null)
            {
                to = DateTime.Now;
            }

            var reviews = await this._db.Reviews
                .Where(r => r.IsApproved)
                .Where(r => r.Score >= minStars * 2 && r.Score <= maxStars * 2)
                .Where(r => r.ReviewedOn.CompareTo(from) >= 0)
                .Where(r => r.ReviewedOn.CompareTo(to) <= 0)
                .ProjectTo<ReviewDetailsModel>()
                .ToListAsync();

            switch (order)
            {
                case ReviewOrder.StarsAscending:
                    return reviews.OrderBy(r => r.Score);
                case ReviewOrder.StarsDescending:
                    return reviews.OrderByDescending(r => r.Score);
                case ReviewOrder.DateAscending:
                    return reviews.OrderBy(r => r.ReviewedOn);
                case ReviewOrder.DateDescending:
                    return reviews.OrderByDescending(r => r.ReviewedOn);
                default:
                    return reviews;
            }
        }
    }
}