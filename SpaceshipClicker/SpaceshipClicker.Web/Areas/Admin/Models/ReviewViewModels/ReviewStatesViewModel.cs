namespace SpaceshipClicker.Web.Areas.Admin.Models.ReviewViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ReviewStatesViewModel
    {
        [Display(Name = "Approved")]
        public bool IsApproved { get; set; }

        [Display(Name = "Default")]
        public bool IsDefault { get; set; }
    }
}