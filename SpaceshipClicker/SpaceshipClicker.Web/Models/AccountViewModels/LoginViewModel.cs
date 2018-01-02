namespace SpaceshipClicker.Web.Models.AccountViewModels
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required]
        [StringLength(GlobalConstants.UsernameMaxLength, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = GlobalConstants.UsernameMinLength)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}