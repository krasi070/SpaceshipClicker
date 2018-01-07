namespace SpaceshipClicker.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SpaceshipClicker.Services;
    using SpaceshipClicker.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Produces("application/json")]
    [Route("api/Emails")]
    public class EmailAPIController : Controller
    {
        private readonly ICrewmateEmailService _crewmateEmails;

        public EmailAPIController(ICrewmateEmailService crewmateEmails)
        {
            this._crewmateEmails = crewmateEmails;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IEnumerable<CrewmateEmailModel>> All()
            => await this._crewmateEmails.GetAllAsync();
    }
}