namespace SpaceshipClicker.Services
{
    using Models.Users;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        int Total { get; }

        Task<IEnumerable<UserListingModel>> GetAllAsync(int page, int pageSize);

        Task<IEnumerable<UserListingModel>> GetAllMatchesAsync(string searchStr, int page, int pageSize);

        Task<UserDetailsModel> GetByIdAsync(string id);

        Task NameSpaceship(string userId, string spaceshipName);

        Task<bool> HasSpaceshipName(string userId);
    }
}