namespace SpaceshipClicker.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SpaceshipClicker.Services;
    using SpaceshipClicker.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Produces("application/json")]
    [Route("api/Names")]
    public class NameAPIController : Controller
    {
        private readonly ICrewmateNameService _crewmateNames;

        public NameAPIController(ICrewmateNameService crewmateNames)
        {
            this._crewmateNames = crewmateNames;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IEnumerable<CrewmateNameModel>> All()
            => await this._crewmateNames.GetAllAsync();
    }
}