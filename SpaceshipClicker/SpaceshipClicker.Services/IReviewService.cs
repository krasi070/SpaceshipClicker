namespace SpaceshipClicker.Services
{
    using Data.Models;
    using Models.Reviews;
    using System;
    using System.Collections.Generic;

    public interface IReviewService
    {
        int Total { get; }

        IEnumerable<ReviewDefaultModel> GetDefault(int amount = 3);

        IEnumerable<ReviewDetailsModel> GetAllApproved(ReviewOrder order = ReviewOrder.DateDescending, int page = 0, int pageSize = 20);

        IEnumerable<ReviewAdminDetailsModel> GetAllWithDetails(bool approved, bool notApproved, bool @default, bool notDefault, int page = 0, int pageSize = 20);

        IEnumerable<ReviewDetailsModel> GetFilteredReviews(ReviewOrder order, float? minStars = null, float? maxStars = null, DateTime? from = null, DateTime? to = null);

        void Create(string text, int score, string userId);

        void Edit(int id, string text, int score);

        void Delete(int id);

        bool HasUserPostedReview(string username);

        void ChangeStates(int id, bool approved, bool @default);

        ReviewAdminDetailsModel GetById(int id);
    }
}