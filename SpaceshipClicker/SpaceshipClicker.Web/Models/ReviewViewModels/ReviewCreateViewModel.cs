namespace SpaceshipClicker.Web.Models.ReviewViewModels
{
    using Constants;
    using Infrastructure.Attributes;
    using System.ComponentModel.DataAnnotations;

    public class ReviewCreateViewModel
    {
        [MinLength(GlobalConstants.ReviewMinTextLength)]
        [MaxLength(GlobalConstants.ReviewMaxTextLength)]
        [Display(Name = "Review")]
        public string Text { get; set; }

        [ReviewStars(ErrorMessage = "Stars must be from 0.5 to 5 and only integers and halves are allowed!")]
        public float Stars { get; set; }
    }
}