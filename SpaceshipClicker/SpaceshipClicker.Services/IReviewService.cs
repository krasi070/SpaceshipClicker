namespace SpaceshipClicker.Services
{
    using Models.Reviews;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReviewService
    {
        int Total { get; }

        Task<IEnumerable<ReviewDefaultModel>> GetDefaultAsync(int amount = 3);

        Task<IEnumerable<ReviewDetailsModel>> GetAllApprovedAsync(ReviewOrder order = ReviewOrder.DateDescending, int page = 0, int pageSize = 20);

        Task<IEnumerable<ReviewAdminDetailsModel>> GetAllWithDetailsAsync(bool approved, bool notApproved, bool @default, bool notDefault, int page = 0, int pageSize = 20);

        Task<IEnumerable<ReviewDetailsModel>> GetFilteredReviewsAsync(ReviewOrder order, float? minStars = null, float? maxStars = null, DateTime? from = null, DateTime? to = null);

        Task CreateAsync(string text, int score, string userId);

        Task EditAsync(int id, string text, int score);

        Task DeleteAsync(int id);

        Task<bool> HasUserPostedReviewAsync(string username);

        Task ChangeStatesAsync(int id, bool approved, bool @default);

        Task<ReviewAdminDetailsModel> GetByIdAsync(int id);
    }
}