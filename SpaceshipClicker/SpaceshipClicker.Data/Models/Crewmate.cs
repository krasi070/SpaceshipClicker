namespace SpaceshipClicker.Data.Models
{
    using Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Crewmate
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public Race Race { get; set; }

        public Emotion Emotion { get; set; }

        public int? CrushId { get; set; }

        public Crewmate Crush { get; set; }

        [Range(0, 5)]
        public int DepressionLevel { get; set; }

        [Range(0, long.MaxValue)]
        public long UnitsPerSecond { get; set; }

        [Range(0, long.MaxValue)]
        public long TotalUnitsEarned { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public List<Tweet> Tweets { get; set; } = new List<Tweet>();
    }
}