namespace SpaceshipClicker.Services.Implementations
{
    using Data;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SpaceshipClicker.Services.Models.Reviews;

    public class ReviewService : IReviewService
    {
        private readonly SpaceshipClickerDbContext _db;

        public ReviewService(SpaceshipClickerDbContext db)
        {
            this._db = db;
        }

        public int Total { get; set; }

        public void Create(string text, int score, string userId)
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
            this._db.SaveChanges();
        }

        public IEnumerable<AdminDetailsReviewModel> GetAllWithDetails(bool approved, bool notApproved, bool @default, bool notDefault, int page = 0, int pageSize = 20)
        {
            List<AdminDetailsReviewModel> reviews = new List<AdminDetailsReviewModel>();
            IEnumerable<AdminDetailsReviewModel> result = new List<AdminDetailsReviewModel>();
            if (page > 0)
            {
                if (approved)
                {
                    reviews.AddRange(this._db.Reviews
                        .Where(r => r.IsApproved)
                        .Select(r => new AdminDetailsReviewModel()
                        {
                            Id = r.Id,
                            Text = r.Text,
                            Score = r.Score,
                            ReviewedOn = r.ReviewedOn,
                            ByUser = r.User.UserName,
                            UserId = r.UserId,
                            IsApproved = r.IsApproved,
                            IsDefault = r.IsDefault
                        }));
                }

                if (notApproved)
                {
                    reviews.AddRange(this._db.Reviews
                        .Where(r => !r.IsApproved)
                        .Select(r => new AdminDetailsReviewModel()
                        {
                            Id = r.Id,
                            Text = r.Text,
                            Score = r.Score,
                            ReviewedOn = r.ReviewedOn,
                            ByUser = r.User.UserName,
                            UserId = r.UserId,
                            IsApproved = r.IsApproved,
                            IsDefault = r.IsDefault
                        }));
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
            else
            {
                result = this._db.Reviews
                    .OrderByDescending(r => r.ReviewedOn)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(r => new AdminDetailsReviewModel()
                    {
                        Id = r.Id,
                        Text = r.Text,
                        Score = r.Score,
                        ReviewedOn = r.ReviewedOn,
                        ByUser = r.User.UserName,
                        UserId = r.UserId,
                        IsApproved = r.IsApproved,
                        IsDefault = r.IsDefault
                    });
            }

            return result;
        }

        public IEnumerable<DetailsReviewModel> GetAllApproved(ReviewOrder order = ReviewOrder.DateDescending, int page = 0, int pageSize = 20)
        {
            IEnumerable<DetailsReviewModel> reviews = new List<DetailsReviewModel>();
            if (page > 0)
            {
                reviews = this._db.Reviews
                    .Where(r => r.IsApproved)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(r => new DetailsReviewModel()
                    {
                        Text = r.Text,
                        Score = r.Score,
                        ReviewedOn = r.ReviewedOn,
                        ByUser = r.User.UserName
                    });
            }
            else
            {
                reviews = this._db.Reviews
                    .Where(r => r.IsApproved)
                    .Select(r => new DetailsReviewModel()
                    {
                        Text = r.Text,
                        Score = r.Score,
                        ReviewedOn = r.ReviewedOn,
                        ByUser = r.User.UserName
                    });
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

        public IEnumerable<DefaultReviewModel> GetDefault(int amount = 3)
            => this._db.Reviews
                .Where(r => r.IsDefault)
                .OrderByDescending(r => r.ReviewedOn)
                .Take(amount)
                .Select(r => new DefaultReviewModel()
                {
                    Text = r.Text,
                    Score = r.Score
                });

        public IEnumerable<DetailsReviewModel> GetFilteredReviews(ReviewOrder order, float? minStars = null, float? maxStars = null, DateTime? from = null, DateTime? to = null)
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

            var reviews = this._db.Reviews
                .Where(r => r.IsApproved)
                .Where(r => r.Score >= minStars * 2 && r.Score <= maxStars * 2)
                .Where(r => r.ReviewedOn.CompareTo(from) >= 0)
                .Where(r => r.ReviewedOn.CompareTo(to) <= 0)
                .Select(r => new DetailsReviewModel()
                {
                    Text = r.Text,
                    Score = r.Score,
                    ReviewedOn = r.ReviewedOn,
                    ByUser = r.User.UserName
                });

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