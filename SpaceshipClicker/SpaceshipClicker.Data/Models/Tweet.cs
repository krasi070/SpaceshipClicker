namespace SpaceshipClicker.Data.Models
{
    using Constants;
    using Enums;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        public int Id { get; set; }

        [Required]
        [MinLength(Constants.TweetMinTextLength)]
        [MaxLength(Constants.TweetMaxTextLength)]
        public string Text { get; set; }

        public Emotion Emotion { get; set; }

        public int MinDepressionLevel { get; set; }

        public int MaxDepressionLevel { get; set; }

        public int CrewmateId { get; set; }

        public Crewmate Crewmate { get; set; }
    }
}