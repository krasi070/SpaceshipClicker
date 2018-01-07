namespace SpaceshipClicker.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICrewmateEmailService
    {
        int Total { get; }

        Task<IEnumerable<CrewmateEmailModel>> GetAllAsync();

        Task<IEnumerable<CrewmateEmailModel>> GetAllAsync(int page, int pageSize);

        Task<IEnumerable<CrewmateEmailModel>> GetFilteredAsync(int page, int pageSize, int minDepressionLevel = -1, int maxDepressionLevel = -1);

        Task<CrewmateEmailModel> GetByIdAsync(int id);

        Task CreateAsync(string text, int minDepressionLevel, int maxDepressionLevel);

        Task EditAsync(int id, string text, int minDepressionLevel, int maxDepressionLevel);

        Task DeleteAsync(int id);
    }
}