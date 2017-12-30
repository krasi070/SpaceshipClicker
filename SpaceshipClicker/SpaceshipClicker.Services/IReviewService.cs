namespace SpaceshipClicker.Services
{
    using Models.Reviews;
    using System;
    using System.Collections.Generic;

    public interface IReviewService
    {
        IEnumerable<DefaultReviewModel> GetDefault(int amount = 3);

        IEnumerable<DetailsReviewModel> GetAll(ReviewOrder order);

        IEnumerable<DetailsReviewModel> GetFilteredReviews(ReviewOrder order, float? minStars = null, float? maxStars = null, DateTime? from = null, DateTime? to = null);

        void Create(string text, int score, string userId);
    }
}