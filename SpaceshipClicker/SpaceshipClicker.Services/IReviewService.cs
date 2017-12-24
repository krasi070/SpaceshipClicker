namespace SpaceshipClicker.Services
{
    using Models.Reviews;
    using System.Collections.Generic;

    public interface IReviewService
    {
        IEnumerable<DefaultReviewModel> GetDefault(int amount = 3);

        IEnumerable<DetailsReviewModel> GetAll();

        // TODO: Add filter parameters
        IEnumerable<DetailsReviewModel> GetFilteredReviews();

        void Create(string text, int score, string userId);
    }
}