namespace SpaceshipClicker.Data.Models
{
    using Constants;
    using Enums;
    using System.ComponentModel.DataAnnotations;

    public class CrewmateName
    {
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.CrewmateMinNameLength)]
        [MaxLength(GlobalConstants.CrewmateMaxNameLength)]
        public string Name { get; set; }

        public Race Race { get; set; }

        public Gender Gender { get; set; }
    }
}