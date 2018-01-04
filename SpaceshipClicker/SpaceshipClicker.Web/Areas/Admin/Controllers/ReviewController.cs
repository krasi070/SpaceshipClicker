namespace SpaceshipClicker.Web.Areas.Admin.Controllers
{
    using Constants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.ReviewViewModels;
    using SpaceshipClicker.Services;
    using System;
    using System.Linq;

    [Area("Admin")]
    [Route("Admin")]
    public class ReviewController : Controller
    {
        private const int PageSize = 20;

        private readonly IReviewService _reviews;

        public ReviewController(IReviewService reviews)
        {
            this._reviews = reviews;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRole)]
        [Route("Review/List/{page}")]
        public IActionResult List(int page, ReviewPageFilterViewModel model)
        {
            if (page < 1)
            {
                return NotFound();
            }

            var reviews = this._reviews.GetAllWithDetails(
                    model.DisplayApproved,
                    model.DisplayNotApproved,
                    model.DisplayDefault,
                    model.DisplayNotDefault,
                    page,
                    PageSize);

            return View(new ReviewPageViewModel()
            {
                Reviews = reviews,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this._reviews.Total / (double)PageSize),
                DisplayApproved = model.DisplayApproved,
                DisplayNotApproved = model.DisplayNotApproved,
                DisplayDefault = model.DisplayDefault,
                DisplayNotDefault = model.DisplayNotDefault
            });
        }
    }
}