namespace SpaceshipClicker.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Text { get; set; }

        [Range(0, int.MaxValue)]
        public int Order { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}