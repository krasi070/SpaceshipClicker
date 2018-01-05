namespace SpaceshipClicker.Services
{
    using Models.Users;
    using System.Collections.Generic;

    public interface IUserService
    {
        int Total { get; }

        IEnumerable<UserListingModel> GetAll(int page, int pageSize);

        IEnumerable<UserListingModel> GetAllMatches(string searchStr, int page, int pageSize);

        UserDetailsModel GetById(string id);
    }
}