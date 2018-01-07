namespace SpaceshipClicker.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CrewmateEmailService : ICrewmateEmailService
    {
        private readonly SpaceshipClickerDbContext _db;

        public CrewmateEmailService(SpaceshipClickerDbContext db)
        {
            this._db = db;
        }

        public int Total { get; set; }

        public async Task CreateAsync(string text, int minDepressionLevel, int maxDepressionLevel)
        {
            CrewmateEmail email = new CrewmateEmail()
            {
                Text = text,
                MinDepressionLevel = minDepressionLevel,
                MaxDepressionLevel = maxDepressionLevel
            };

            this._db.CrewmateEmails.Add(email);
            await this._db.SaveChangesAsync();
        }

        public async Task EditAsync(int id, string text, int minDepressionLevel, int maxDepressionLevel)
        {
            var email = await this._db.CrewmateEmails.FindAsync(id);
            if (email == null)
            {
                return;
            }

            email.Text = text;
            email.MinDepressionLevel = minDepressionLevel;
            email.MaxDepressionLevel = maxDepressionLevel;

            await this._db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var email = await this._db.CrewmateEmails.FindAsync(id);
            if (email == null)
            {
                return;
            }

            this._db.CrewmateEmails.Remove(email);
            await this._db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CrewmateEmailModel>> GetAllAsync()
            => await this._db.CrewmateEmails
                .ProjectTo<CrewmateEmailModel>()
                .ToListAsync();

        public async Task<IEnumerable<CrewmateEmailModel>> GetAllAsync(int page, int pageSize)
        {
            this.Total = this._db.CrewmateEmails.Count();

            return await this._db.CrewmateEmails
                .OrderByDescending(ce => ce.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<CrewmateEmailModel>()
                .ToListAsync();
        }

        public async Task<IEnumerable<CrewmateEmailModel>> GetFilteredAsync(int page, int pageSize, int minDepressionLevel = -1, int maxDepressionLevel = -1)
        {
            var emails = this._db.CrewmateEmails
                .Where(ce => ce.MinDepressionLevel >= minDepressionLevel && ce.MaxDepressionLevel <= maxDepressionLevel)
                .OrderByDescending(ce => ce.Id);

            this.Total = emails.Count();

            return await emails
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<CrewmateEmailModel>()
                .ToListAsync();
        }

        public async Task<CrewmateEmailModel> GetByIdAsync(int id)
            => await this._db.CrewmateEmails
                .Where(ce => ce.Id == id)
                .ProjectTo<CrewmateEmailModel>()
                .FirstOrDefaultAsync();
    }
}