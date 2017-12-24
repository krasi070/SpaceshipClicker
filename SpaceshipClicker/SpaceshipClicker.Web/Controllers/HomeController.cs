namespace SpaceshipClicker.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using SpaceshipClicker.Services;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IReviewService _reviews;

        public HomeController(IReviewService reviews)
        {
            this._reviews = reviews;
        }

        public IActionResult Index()
            => View(this._reviews.GetDefault());
        

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}