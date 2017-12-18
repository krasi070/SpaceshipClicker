namespace SpaceshipClicker.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        public int Id { get; set; }

        [MaxLength(280)]
        public string Text { get; set; }

        [Range(1, 10)]
        public int Score { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDefault { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}