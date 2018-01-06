namespace SpaceshipClicker.Services.Models.Users
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System;

    public class UserDetailsModel : UserListingModel, IMapFrom<User>, IHaveCustomMapping
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

        public override void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<User, UserDetailsModel>()
                .ForMember(u => u.Username, cfg => cfg.MapFrom(u => u.UserName))
                .ForMember(u => u.Stars, cfg => cfg.MapFrom(u => u.Review != null ? u.Review.Score / 2f : 0f))
                .ForMember(u => u.Review, cfg => cfg.MapFrom(u => u.Review != null ? u.Review.Text : null))
                .ForMember(u => u.ReviewedOn, cfg => cfg.MapFrom(u => u.Review != null ? u.Review.ReviewedOn : DateTime.Now));
    }
}