namespace SpaceshipClicker.Data.Models
{
    using Constants;
    using Enums;
    using System.ComponentModel.DataAnnotations;

    public class Crewmate
    {
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.CrewmateMinNameLength)]
        [MaxLength(GlobalConstants.CrewmateMaxNameLength)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public Race Race { get; set; }

        [Range(GlobalConstants.CrewmateMinDepressionLevel, GlobalConstants.CrewmateMaxDepressionLevel)]
        public int DepressionLevel { get; set; }

        [Range(GlobalConstants.MinUnits, long.MaxValue)]
        public long UnitsPerSecond { get; set; }

        [Range(GlobalConstants.MinUnits, long.MaxValue)]
        public long TotalUnitsEarned { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}