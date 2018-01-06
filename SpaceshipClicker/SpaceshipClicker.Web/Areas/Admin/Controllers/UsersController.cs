namespace SpaceshipClicker.Web.Areas.Admin.Controllers
{
    using Constants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SpaceshipClicker.Services;
    using SpaceshipClicker.Services.Models.Users;
    using SpaceshipClicker.Web.Areas.Admin.Models.UserViewModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Area("Admin")]
    [Route("Admin")]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class UsersController : Controller
    {
        private const int PageSize = 20;

        private readonly IUserService _users;

        public UsersController(IUserService users)
        {
            this._users = users;
        }

        [Route("Users/List/{page}")]
        public async Task<IActionResult> List(int page, UserSearchViewModel model)
        {
            if (page < 1)
            {
                return NotFound();
            }

            IEnumerable<UserListingModel> users = new List<UserListingModel>();
            if (string.IsNullOrEmpty(model.SearchUsername))
            {
                users = await this._users.GetAllAsync(page, PageSize);
            }
            else
            {
                users = await this._users.GetAllMatchesAsync(model.SearchUsername, page, PageSize);
            }

            return View(new UserPageViewModel()
            {
                Users = users,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this._users.Total / (double)PageSize)
            });
        }

        [Route("Users/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            var user = await this._users.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
    }
}