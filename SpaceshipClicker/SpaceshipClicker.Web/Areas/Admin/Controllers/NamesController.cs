namespace SpaceshipClicker.Web.Areas.Admin.Controllers
{
    using Constants;
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.CrewmateNameViewModels;
    using SpaceshipClicker.Services;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Admin")]
    [Route("Admin")]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class NamesController : Controller
    {
        private const int PageSize = 20;

        private readonly ICrewmateNameService _crewmateNames;

        public NamesController(ICrewmateNameService names)
        {
            this._crewmateNames = names;
        }

        [Route("Names/List/{race}/{page}")]
        public async Task<IActionResult> List(string race, int page, CrewmateNameFormViewModel model)
        {
            if (string.IsNullOrEmpty(race) || page < 1)
            {
                return NotFound();
            }

            object raceObj = Race.All;
            Enum.TryParse(typeof(Race), race, out raceObj);
            if (raceObj == null)
            {
                return NotFound();
            }
            else
            {
                raceObj = (Race)raceObj;
            }

            TempData["PathAndQuery"] = "/Admin/Names/List/" + race.ToString() + "/" + page;
            if ((model == null || string.IsNullOrEmpty(model.SearchName)) && (Race)raceObj == Race.All)
            {
                return View(new CrewmateNamePageViewModel()
                {
                    Names = await this._crewmateNames.GetAllAsync(page, PageSize),
                    CurrentPage = page,
                    TotalPages = (int)Math.Ceiling(this._crewmateNames.Total / (double)PageSize),
                    Race = (Race)raceObj
                });
            }
            else if ((model == null || string.IsNullOrEmpty(model.SearchName)) && (Race)raceObj != Race.All)
            {
                return View(new CrewmateNamePageViewModel()
                {
                    Names = await this._crewmateNames.GetAllOfRaceAsync((Race)raceObj, page, PageSize),
                    CurrentPage = page,
                    TotalPages = (int)Math.Ceiling(this._crewmateNames.Total / (double)PageSize),
                    Race = (Race)raceObj
                });
            }
            else if (!string.IsNullOrEmpty(model.SearchName) && (Race)raceObj == Race.All)
            {
                var names = await this._crewmateNames.GetAllMatchesAsync(model.SearchName, page, PageSize);
                if (names.Count() == 0 && this._crewmateNames.Total > 0)
                {
                    return Redirect("/Admin/Names/List/All/1" + HttpContext.Request.QueryString.Value);
                }

                TempData["PathAndQuery"] += HttpContext.Request.QueryString.Value;
                return View(new CrewmateNamePageViewModel()
                {
                    Names = names,
                    CurrentPage = page,
                    TotalPages = (int)Math.Ceiling(this._crewmateNames.Total / (double)PageSize),
                    SearchName = model.SearchName,
                    Race = (Race)raceObj
                });
            }
            else
            {
                var names = await this._crewmateNames.GetAllMatchesAsync((Race)raceObj, model.SearchName, page, PageSize);
                if (names.Count() == 0 && this._crewmateNames.Total > 0)
                {
                    return Redirect("/Admin/Names/List/" + ((Race)(raceObj)).ToString() + "/1" + HttpContext.Request.QueryString.Value);
                }

                TempData["PathAndQuery"] += HttpContext.Request.QueryString.Value;
                return View(new CrewmateNamePageViewModel()
                {
                    Names = names,
                    CurrentPage = page,
                    TotalPages = (int)Math.Ceiling(this._crewmateNames.Total / (double)PageSize),
                    SearchName = model.SearchName,
                    Race = (Race)raceObj
                });
            }
        }

        [HttpPost]
        [Route("Names/List/{race}/{page}")]
        public async Task<IActionResult> List(string race, int page, CrewmateNamePageViewModel model)
        {
            await this._crewmateNames.Create(model.AddName, model.AddGender, model.AddRace);

            return Redirect(TempData["PathAndQuery"].ToString());
        }

        [Route("Names/Destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            await this._crewmateNames.Delete(id);

            return Redirect(TempData["PathAndQuery"].ToString());
        }
    }
}