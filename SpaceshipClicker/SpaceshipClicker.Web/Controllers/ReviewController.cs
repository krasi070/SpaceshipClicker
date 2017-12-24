namespace SpaceshipClicker.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SpaceshipClicker.Services;

    public class ReviewController : Controller
    {
        private readonly IReviewService _reviews;

        public ReviewController(IReviewService reviews)
        {
            this._reviews = reviews;
        }

        public IActionResult List()
            => View(this._reviews.GetAll());
    }
}