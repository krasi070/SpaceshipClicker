namespace SpaceshipClicker.Services.Models.Users
{
    public class UserListingModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string SpaceshipName { get; set; }

        public float Stars { get; set; }

        public int? ReviewId { get; set; }
    }
}