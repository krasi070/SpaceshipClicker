namespace SpaceshipClicker.Web.Models.ReviewViewModels
{
    using Constants;
    using Infrastructure.Attributes;
    using System.ComponentModel.DataAnnotations;

    public class ReviewFormViewModel
    {
        [MinLength(GlobalConstants.ReviewMinTextLength, ErrorMessage = "The Review field must be at least {1} characters long!")]
        [MaxLength(GlobalConstants.ReviewMaxTextLength, ErrorMessage = "The Review field must not be longer than {1} characters!")]
        [Required]
        [Display(Name = "Review")]
        public string Text { get; set; }

        [ReviewStars(ErrorMessage = "Stars must be from 0.5 to 5 and only integers and halves are allowed!")]
        public float Stars { get; set; }
    }
}