namespace SpaceshipClicker.Services.Models.Reviews
{
    using System;

    public class DetailsReviewModel : DefaultReviewModel
    {
        public string ByUser { get; set; }

        public DateTime ReviewedOn { get; set; }
    }
}