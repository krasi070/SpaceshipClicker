namespace SpaceshipClicker.Services.Models.Reviews
{
    using Common.Mapping;
    using Data.Models;

    public class ReviewAdminDetailsModel : ReviewDetailsModel, IMapFrom<Review>, IHaveCustomMapping
    {
        public string UserId { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDefault { get; set; }
    }
}