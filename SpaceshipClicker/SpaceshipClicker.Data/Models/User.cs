namespace SpaceshipClicker.Data.Models
{
    using Constants;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        [MinLength(GlobalConstants.SpaceshipNameMinLength)]
        [MaxLength(GlobalConstants.SpaceshipNameMaxLength)]
        public string SpaceshipName { get; set; }

        [Range(GlobalConstants.MinUnits, long.MaxValue)]
        public long Units { get; set; }

        [Range(GlobalConstants.MinUnits, long.MaxValue)]
        public long UnitsPerClick { get; set; }

        [Range(GlobalConstants.MinUnits, long.MaxValue)]
        public long UnitsPerSecond { get; set; }

        [Range(GlobalConstants.MinAiLevel, GlobalConstants.MaxAiLevel)]
        public int AiLevel { get; set; }

        public bool HasBathroom { get; set; }

        public bool HasCoffee { get; set; }

        public bool HasEnhancements { get; set; }

        public int? ReviewId { get; set; }

        public Review Review { get; set; }

        public List<Crewmate> Crew { get; set; } = new List<Crewmate>();

        public List<BottleMessage> BottleMessages { get; set; } = new List<BottleMessage>();

        public List<Notification> Notifications { get; set; } = new List<Notification>();
    }
}