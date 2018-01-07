namespace SpaceshipClicker.Web.Areas.Admin.Models.CrewmateEmailViewModels
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class CrewmateEmailFormViewModel : CrewmateEmailFilterViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Content")]
        [Required]
        [MinLength(GlobalConstants.EmailMinTextLength, ErrorMessage = "The content must be at least {1} character(s) long!")]
        [MaxLength(GlobalConstants.EmailMaxTextLength, ErrorMessage = "The content must not be longer than {1} characters!")]
        public string AddText { get; set; }

        [Display(Name = "Min Depression Level")]
        [Required]
        [Range(GlobalConstants.CrewmateMinDepressionLevel, GlobalConstants.CrewmateMaxDepressionLevel)]
        public int AddMinDepressionLevel { get; set; }

        [Display(Name = "Max Depression Level")]
        [Required]
        [Range(GlobalConstants.CrewmateMinDepressionLevel, GlobalConstants.CrewmateMaxDepressionLevel)]
        public int AddMaxDepressionLevel { get; set; }
    }
}