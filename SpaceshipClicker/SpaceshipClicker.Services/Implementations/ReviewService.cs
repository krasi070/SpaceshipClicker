﻿namespace SpaceshipClicker.Services.Implementations
{
    using Data;
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

        public void Create(string text, int score, string userId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<DetailsReviewModel> GetAll()
            => this._db.Reviews
                .Where(r => r.IsApproved)
                .Select(r => new DetailsReviewModel()
                {
                    Text = r.Text,
                    Score = r.Score,
                    ReviewedOn = r.ReviewedOn,
                    ByUser = r.User.UserName
                });

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

        public IEnumerable<DetailsReviewModel> GetFilteredReviews()
        {
            throw new System.NotImplementedException();
        }
    }
}