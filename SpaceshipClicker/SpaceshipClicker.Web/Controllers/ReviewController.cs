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
    using System.Linq;

    public class ReviewController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IReviewService _reviews;

        public ReviewController(UserManager<User> userManager, IReviewService reviews)
        {
            this._userManager = userManager;
            this._reviews = reviews;
        }

        [AllowAnonymous]
        [Route("Review/List/{order}")]
        public IActionResult List(string order, FilterViewModel model)
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
                    Reviews = this._reviews.GetAllApproved(reviewOrder)
                });
            } 

            return View(new ReviewListViewModel()
            {
                Order = reviewOrder,
                Reviews = this._reviews.GetFilteredReviews(reviewOrder, model.MinStars, model.MaxStars, model.From, model.To)
            });
        }

        [Authorize]
        public IActionResult Create()
        {
            if (this._reviews.GetAllApproved().Any(r => r.ByUser == this._userManager.GetUserName(User)))
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ReviewCreateViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this._reviews.Create(model.Text, (int)Math.Round(model.Stars * 2), this._userManager.GetUserId(HttpContext.User));

            return Redirect("List/DateDescending");
        }
    }
}