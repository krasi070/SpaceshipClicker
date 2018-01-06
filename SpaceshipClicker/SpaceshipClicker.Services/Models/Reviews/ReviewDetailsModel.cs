namespace SpaceshipClicker.Services.Models.Reviews
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System;

    public class ReviewDetailsModel : ReviewDefaultModel, IMapFrom<Review>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string ByUser { get; set; }

        public DateTime ReviewedOn { get; set; }

        public override void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<Review, ReviewDetailsModel>()
                .ForMember(r => r.ByUser, cfg => cfg.MapFrom(r => r.User.UserName));
    }
}