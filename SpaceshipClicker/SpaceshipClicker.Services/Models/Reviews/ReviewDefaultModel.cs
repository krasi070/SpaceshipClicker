namespace SpaceshipClicker.Services.Models.Reviews
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class ReviewDefaultModel : IMapFrom<Review>, IHaveCustomMapping
    {
        public string Text { get; set; }

        public int Score { get; set; }

        public virtual void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<Review, ReviewDefaultModel>();
    }
}