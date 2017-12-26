namespace SpaceshipClicker.Web.Models.ReviewViewModels
{
    using SpaceshipClicker.Services.Models.Reviews;
    using System.Collections.Generic;

    public class ReviewListViewModel : FilterViewModel
    {
        public IEnumerable<DetailsReviewModel> Reviews { get; set; }
    }
}