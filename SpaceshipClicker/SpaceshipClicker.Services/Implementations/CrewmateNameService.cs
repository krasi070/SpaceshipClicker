namespace SpaceshipClicker.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CrewmateNameService : ICrewmateNameService
    {
        private readonly SpaceshipClickerDbContext _db;

        public CrewmateNameService(SpaceshipClickerDbContext db)
        {
            this._db = db;
        }

        public int Total { get; set; }

        public async Task CreateAsync(string name, Gender gender, Race race)
        {
            CrewmateName crewmateName = new CrewmateName()
            {
                Name = name,
                Gender = gender,
                Race = race
            };

            this._db.CrewmateNames.Add(crewmateName);
            await this._db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var crewmateName = await this._db.CrewmateNames.FindAsync(id);
            if (crewmateName == null)
            {
                return;
            }

            this._db.CrewmateNames.Remove(crewmateName);
            await this._db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CrewmateNameModel>> GetAllAsync()
            => await this._db.CrewmateNames
                .ProjectTo<CrewmateNameModel>()
                .ToListAsync();

        public async Task<IEnumerable<CrewmateNameModel>> GetAllAsync(int page, int pageSize)
        {
            this.Total = this._db.CrewmateNames.Count();

            return await this._db.CrewmateNames
                .OrderBy(cn => cn.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<CrewmateNameModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<CrewmateNameModel>> GetAllMatchesAsync(string searchStr, int page, int pageSize)
        {
            var names = this._db.CrewmateNames
                .Where(cn => cn.Name.Contains(searchStr));

            this.Total = names.Count();

            return await names
                .OrderBy(cn => cn.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<CrewmateNameModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<CrewmateNameModel>> GetAllMatchesAsync(Race race, string searchStr, int page, int pageSize)
        {
            var names = this._db.CrewmateNames
                .Where(cn => cn.Name.Contains(searchStr) && cn.Race == race);

            this.Total = names.Count();

            return await names
                .OrderBy(cn => cn.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<CrewmateNameModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<CrewmateNameModel>> GetAllOfRaceAsync(Race race, int page, int pageSize)
        {
            var names = this._db.CrewmateNames
                .Where(cn => cn.Race == race);

            this.Total = names.Count();

            return await names
                .OrderBy(cn => cn.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<CrewmateNameModel>()
                .ToListAsync();
        }

        public async Task<CrewmateNameModel> GetByIdAsync(int id)
            => await this._db.CrewmateNames
                .Where(cn => cn.Id == id)
                .ProjectTo<CrewmateNameModel>()
                .FirstOrDefaultAsync();
    }
}