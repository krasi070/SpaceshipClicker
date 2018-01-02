namespace SpaceshipClicker.Data.Models
{
    using Constants;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        public int Id { get; set; }

        [MinLength(GlobalConstants.ReviewMinTextLength)]
        [MaxLength(GlobalConstants.ReviewMaxTextLength)]
        public string Text { get; set; }

        [Range(GlobalConstants.ReviewMinScore, GlobalConstants.ReviewMaxScore)]
        public int Score { get; set; }

        public DateTime ReviewedOn { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDefault { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}