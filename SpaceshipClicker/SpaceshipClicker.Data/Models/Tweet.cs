namespace SpaceshipClicker.Data.Models
{
    using Enums;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(140)]
        public string Text { get; set; }

        public Emotion Emotion { get; set; }

        public int MinDepressionLevel { get; set; }

        public int MaxDepressionLevel { get; set; }

        public int CrewmateId { get; set; }

        public Crewmate Crewmate { get; set; }
    }
}