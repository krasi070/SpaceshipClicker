namespace SpaceshipClicker.Web.Areas.Admin.Controllers
{
    using Constants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.ReviewViewModels;
    using SpaceshipClicker.Services;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

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
        public async Task<IActionResult> List(int page, ReviewPageFilterViewModel model)
        {
            if (page < 1)
            {
                return NotFound();
            }

            var reviews = await this._reviews.GetAllWithDetailsAsync(
                    model.DisplayApproved,
                    model.DisplayNotApproved,
                    model.DisplayDefault,
                    model.DisplayNotDefault,
                    page,
                    PageSize);

            if (reviews.Count() == 0 && this._reviews.Total > 0)
            {
                return Redirect("/Admin/Reviews/List/1" + HttpContext.Request.QueryString.Value);
            }

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
        public async Task<IActionResult> Edit(int id)
        {
            var review = await this._reviews.GetByIdAsync(id);
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
        public async Task<IActionResult> Edit(int id, ReviewStatesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this._reviews.ChangeStatesAsync(id, model.IsApproved, model.IsDefault);

            return Redirect("/Admin/Reviews/List/1");
        }
    }
}