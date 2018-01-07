namespace SpaceshipClicker.Services
{
    using Data.Models.Enums;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICrewmateNameService
    {
        int Total { get; }

        Task<IEnumerable<CrewmateNameModel>> GetAllAsync();

        Task<IEnumerable<CrewmateNameModel>> GetAllAsync(int page, int pageSize);

        Task<IEnumerable<CrewmateNameModel>> GetAllOfRaceAsync(Race race, int page, int pageSize);

        Task<IEnumerable<CrewmateNameModel>> GetAllMatchesAsync(string searchStr, int page, int pageSize);

        Task<IEnumerable<CrewmateNameModel>> GetAllMatchesAsync(Race race, string searchStr, int page, int pageSize);

        Task<CrewmateNameModel> GetByIdAsync(int id);

        Task CreateAsync(string name, Gender gender, Race race);

        Task DeleteAsync(int id);
    }
}