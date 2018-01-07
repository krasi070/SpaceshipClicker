namespace SpaceshipClicker.Web.Areas.Game.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Area("Game")]
    [Route("Game")]
    public class GameController : Controller
    {
        public IActionResult Play()
            => View();
    }
}