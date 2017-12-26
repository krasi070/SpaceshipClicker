namespace SpaceshipClicker.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.ReviewViewModels;
    using SpaceshipClicker.Services;
    using System;

    public class ReviewController : Controller
    {
        private readonly IReviewService _reviews;

        public ReviewController(IReviewService reviews)
        {
            this._reviews = reviews;
        }

        public IActionResult List(FilterViewModel model)
        {
            if (model == null || 
                model.MinStars == null || 
                model.MaxStars == null || 
                model.From == null || 
                model.To == null)
            {
                return View(new ReviewListViewModel()
                {
                    Reviews = this._reviews.GetAll()
                });
            } 

            return View(new ReviewListViewModel()
            {
                Reviews = this._reviews.GetFilteredReviews((float)model.MinStars, (float)model.MaxStars, (DateTime)model.From, (DateTime)model.To)
            });
        }
    }
}