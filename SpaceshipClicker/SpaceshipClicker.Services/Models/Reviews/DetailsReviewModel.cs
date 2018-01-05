namespace SpaceshipClicker.Services.Models.Reviews
{
    using System;

    public class DetailsReviewModel : DefaultReviewModel
    {
        public int Id { get; set; }

        public string ByUser { get; set; }

        public DateTime ReviewedOn { get; set; }
    }
}