namespace SpaceshipClicker.Web.Areas.Admin.Controllers
{
    using SpaceshipClicker.Services;

    public class ReviewController
    {
        private readonly IReviewService _reviews;

        public ReviewController(IReviewService reviews)
        {
            this._reviews = reviews;
        }
    }
}