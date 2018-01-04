namespace SpaceshipClicker.Web.Areas.Admin.Models.ReviewViewModels
{
    using SpaceshipClicker.Services.Models.Reviews;
    using System.Collections.Generic;

    public class ReviewPageViewModel : ReviewPageFilterViewModel
    {
        public IEnumerable<AdminDetailsReviewModel> Reviews { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}