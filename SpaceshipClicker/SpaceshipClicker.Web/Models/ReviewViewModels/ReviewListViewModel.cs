namespace SpaceshipClicker.Web.Models.ReviewViewModels
{
    using SpaceshipClicker.Services.Models.Reviews;
    using System.Collections.Generic;

    public class ReviewListViewModel : ReviewFilterViewModel
    {
        public ReviewOrder Order { get; set; }

        public IEnumerable<ReviewDetailsModel> Reviews { get; set; }
    }
}