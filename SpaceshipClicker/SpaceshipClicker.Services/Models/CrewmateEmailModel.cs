namespace SpaceshipClicker.Services.Models
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;

    public class CrewmateEmailModel : IMapFrom<CrewmateEmail>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int MinDepressionLevel { get; set; }

        public int MaxDepressionLevel { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<CrewmateEmail, CrewmateEmailModel>();
    }
}