namespace SpaceshipClicker.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.ReviewViewModels;
    using SpaceshipClicker.Services;
    using SpaceshipClicker.Services.Models.Reviews;
    using System;
    using System.Threading.Tasks;

    public class ReviewsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IReviewService _reviews;

        public ReviewsController(UserManager<User> userManager, IReviewService reviews)
        {
            this._userManager = userManager;
            this._reviews = reviews;
        }

        [AllowAnonymous]
        [Route("Reviews/List/{order}")]
        public async Task<IActionResult> List(string order, ReviewFilterViewModel model)
        {
            if (string.IsNullOrEmpty(order))
            {
                order = ReviewOrder.DateDescending.ToString();
            }

            object reviewObj = null;
            ReviewOrder reviewOrder = ReviewOrder.DateDescending;
            Enum.TryParse(typeof(ReviewOrder), order, out reviewObj);
            if (reviewObj == null)
            {
                return NotFound();
            }
            else
            {
                reviewOrder = (ReviewOrder)reviewObj;
            }

            if (model == null)
            {
                return View(new ReviewListViewModel()
                {
                    Reviews = await this._reviews.GetAllApprovedAsync(reviewOrder)
                });
            } 

            return View(new ReviewListViewModel()
            {
                Order = reviewOrder,
                Reviews = await this._reviews.GetFilteredReviewsAsync(reviewOrder, model.MinStars, model.MaxStars, model.From, model.To)
            });
        }

        [Authorize]
        public async Task<IActionResult> Post()
        {
            if (await this._reviews.HasUserPostedReviewAsync(this._userManager.GetUserName(User)))
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(ReviewFormViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this._reviews.CreateAsync(model.Text, (int)Math.Round(model.Stars * 2), this._userManager.GetUserId(HttpContext.User));

            return Redirect("List/DateDescending");
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            return await this.EditDeleteReview(id, false);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, ReviewFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this._reviews.EditAsync(id, model.Text, (int)(model.Stars * 2));

            return Redirect("/Reviews/List/DateDescending");
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return await this.EditDeleteReview(id, true);
        }

        [Authorize]
        public async Task<IActionResult> Destroy(int id)
        {
            await this._reviews.DeleteAsync(id);

            return Redirect("/Reviews/List/DateDescending");
        }

        private async Task<IActionResult> EditDeleteReview(int id, bool isDelete)
        {
            var review = await this._reviews.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            if (review.UserId != this._userManager.GetUserId(User))
            {
                return Redirect("/Account/AccessDenied");
            }

            if (isDelete)
            {
                return View(new ReviewDeleteViewModel()
                {
                    Id = review.Id,
                    Text = review.Text,
                    Stars = review.Score / 2.0f
                });
            }
            else
            {
                return View(new ReviewFormViewModel()
                {
                    Text = review.Text,
                    Stars = review.Score / 2.0f
                });
            }
        }
    }
}