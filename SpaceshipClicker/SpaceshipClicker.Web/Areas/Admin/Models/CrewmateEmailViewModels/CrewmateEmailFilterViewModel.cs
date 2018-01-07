namespace SpaceshipClicker.Web.Areas.Admin.Models.CrewmateEmailViewModels
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class CrewmateEmailFilterViewModel
    {
        [Display(Name = "Min Depression Level")]
        [Range(GlobalConstants.CrewmateMinDepressionLevel, GlobalConstants.CrewmateMaxDepressionLevel)]
        public int? MinDepressionLevel { get; set; }

        [Display(Name = "Max Depression Level")]
        [Range(GlobalConstants.CrewmateMinDepressionLevel, GlobalConstants.CrewmateMaxDepressionLevel)]
        public int? MaxDepressionLevel { get; set; }
    }
}