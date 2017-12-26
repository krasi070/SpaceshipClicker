namespace SpaceshipClicker.Services
{
    using Models.Reviews;
    using System;
    using System.Collections.Generic;

    public interface IReviewService
    {
        IEnumerable<DefaultReviewModel> GetDefault(int amount = 3);

        IEnumerable<DetailsReviewModel> GetAll();

        IEnumerable<DetailsReviewModel> GetFilteredReviews(float minStars, float maxStars, DateTime from, DateTime to);

        void Create(string text, int score, string userId);
    }
}