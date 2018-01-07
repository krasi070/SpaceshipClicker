namespace SpaceshipClicker.Data.Models
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class CrewmateEmail
    {
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.EmailMinTextLength)]
        [MaxLength(GlobalConstants.EmailMaxTextLength)]
        public string Text { get; set; }

        [Range(GlobalConstants.CrewmateMinDepressionLevel, GlobalConstants.CrewmateMaxDepressionLevel)]
        public int MinDepressionLevel { get; set; }

        [Range(GlobalConstants.CrewmateMinDepressionLevel, GlobalConstants.CrewmateMaxDepressionLevel)]
        public int MaxDepressionLevel { get; set; }
    }
}