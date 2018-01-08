namespace SpaceshipClicker.Web.Areas.Game.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using SpaceshipClicker.Services;
    using System.Threading.Tasks;

    [Area("Game")]
    [Route("Game")]
    public class GameController : Controller
    {
        private readonly IUserService _users;
        private readonly UserManager<User> _userManager;

        public GameController(IUserService users, UserManager<User> userManager)
        {
            this._users = users;
            this._userManager = userManager;
        }

        public async Task<IActionResult> Play()
        {
            if (!(await this._users.HasSpaceshipName(this._userManager.GetUserId(User))))
            {
                return RedirectToAction(nameof(NameSpaceship));
            }

            return View();
        }

        [Authorize]
        [Route("NameSpaceship")]
        public IActionResult NameSpaceship()
            => View();

        [Authorize]
        [HttpPost]
        [Route("NameSpaceship")]
        public async Task<IActionResult> NameSpaceship(UserSpaceshipNameViewModel model)
        {
            var id = this._userManager.GetUserId(User);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this._users.NameSpaceship(id, model.SpaceshipName);

            return RedirectToAction(nameof(Play));
        }
    }
}