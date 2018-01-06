namespace SpaceshipClicker.Services.Models.Users
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class UserListingModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string SpaceshipName { get; set; }

        public float Stars { get; set; }

        public int? ReviewId { get; set; }

        public virtual void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<User, UserListingModel>()
                .ForMember(u => u.Username, cfg => cfg.MapFrom(u => u.UserName))
                .ForMember(u => u.Stars, cfg => cfg.MapFrom(u => u.Review != null ? u.Review.Score / 2f : 0f));
    }
}