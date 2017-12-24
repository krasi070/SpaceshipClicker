namespace SpaceshipClicker.Data.Models
{
    using Constants;
    using Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Crewmate
    {
        public int Id { get; set; }

        [Required]
        [MinLength(Constants.CrewmateMinNameLength)]
        [MaxLength(Constants.CrewmateMaxNameLength)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public Race Race { get; set; }

        public Emotion Emotion { get; set; }

        public int? CrushId { get; set; }

        public Crewmate Crush { get; set; }

        [Range(Constants.CrewmateMinDepressionLevel, Constants.CrewmateMaxDepressionLevel)]
        public int DepressionLevel { get; set; }

        [Range(Constants.MinUnits, long.MaxValue)]
        public long UnitsPerSecond { get; set; }

        [Range(Constants.MinUnits, long.MaxValue)]
        public long TotalUnitsEarned { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public List<Tweet> Tweets { get; set; } = new List<Tweet>();
    }
}