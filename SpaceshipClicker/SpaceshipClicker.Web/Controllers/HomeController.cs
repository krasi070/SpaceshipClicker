namespace SpaceshipClicker.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using SpaceshipClicker.Services;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly IReviewService _reviews;

        public HomeController(IReviewService reviews)
        {
            this._reviews = reviews;
        }

        public async Task<IActionResult> Index()
            => View(await this._reviews.GetDefaultAsync());

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}