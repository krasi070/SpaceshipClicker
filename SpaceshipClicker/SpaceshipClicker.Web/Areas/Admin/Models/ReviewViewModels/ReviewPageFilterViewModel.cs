namespace SpaceshipClicker.Web.Areas.Admin.Models.ReviewViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewPageFilterViewModel
    {
        [Display(Name = "Approved")]
        public bool DisplayApproved { get; set; } = true;

        [Display(Name = "Not Approved")]
        public bool DisplayNotApproved { get; set; } = true;

        [Display(Name = "Default")]
        public bool DisplayDefault { get; set; } = true;

        [Display(Name = "Not Default")]
        public bool DisplayNotDefault { get; set; } = true;
    }
}