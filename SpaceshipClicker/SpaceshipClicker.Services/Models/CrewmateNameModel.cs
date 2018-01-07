namespace SpaceshipClicker.Services.Models
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using Data.Models.Enums;

    public class CrewmateNameModel : IMapFrom<CrewmateName>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Race Race { get; set; }

        public Gender Gender { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<CrewmateName, CrewmateNameModel>();
    }
}