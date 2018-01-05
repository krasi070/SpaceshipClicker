namespace SpaceshipClicker.Services.Models.Users
{
    using System;

    public class UserDetailsModel : UserListingModel
    {
        public string Email { get; set; }

        public long Units { get; set; }

        public long UnitsPerClick { get; set; }

        public long UnitsPerSecond { get; set; }

        public int AiLevel { get; set; }

        public bool HasBathroom { get; set; }

        public bool HasCoffee { get; set; }

        public bool HasEnhancements { get; set; }

        public string Review { get; set; }

        public DateTime ReviewedOn { get; set; }
    }
}