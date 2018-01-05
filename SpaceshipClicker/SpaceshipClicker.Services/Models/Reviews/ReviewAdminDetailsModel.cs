namespace SpaceshipClicker.Services.Models.Reviews
{
    public class ReviewAdminDetailsModel : ReviewDetailsModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDefault { get; set; }
    }
}