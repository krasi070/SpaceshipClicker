namespace SpaceshipClicker.Web.Areas.Admin.Controllers
{
    using Constants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.ReviewViewModels;
    using SpaceshipClicker.Services;
    using System;

    [Area("Admin")]
    [Route("Admin")]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class ReviewsController : Controller
    {
        private const int PageSize = 20;

        private readonly IReviewService _reviews;

        public ReviewsController(IReviewService reviews)
        {
            this._reviews = reviews;
        }
        
        [Route("Reviews/List/{page}")]
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

        [Route("Reviews/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var review = this._reviews.GetById(id);
            if (review == null)
            {
                return NotFound();
            }

            return View(new ReviewEditViewModel()
            {
                Id = review.Id,
                Text = review.Text,
                Stars = review.Score / 2.0f,
                ReviewedOn = review.ReviewedOn,
                UserId = review.UserId,
                Username = review.ByUser,
                IsApproved = review.IsApproved,
                IsDefault = review.IsDefault
            });
        }

        [HttpPost]
        [Route("Reviews/Edit/{id}")]
        public IActionResult Edit(int id, ReviewStatesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this._reviews.ChangeStates(id, model.IsApproved, model.IsDefault);

            return Redirect("/Admin/Reviews/List/1");
        }
    }
}