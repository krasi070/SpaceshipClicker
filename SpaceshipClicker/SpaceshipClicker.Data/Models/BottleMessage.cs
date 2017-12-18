namespace SpaceshipClicker.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BottleMessage
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(1000)]
        public string Text { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDefault { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}