namespace SpaceshipClicker.Web.Areas.Admin.Controllers
{
    using Constants;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models.CrewmateEmailViewModels;
    using SpaceshipClicker.Services;
    using System;
    using System.Threading.Tasks;

    [Area("Admin")]
    [Route("Admin")]
    [Authorize(Roles = GlobalConstants.AdministratorRole)]
    public class EmailsController : Controller
    {
        private const int PageSize = 20;

        private readonly ICrewmateEmailService _crewmateEmails;

        public EmailsController(ICrewmateEmailService crewmateEmails)
        {
            this._crewmateEmails = crewmateEmails;
        }

        [Route("Emails/List/{page}")]
        public async Task<IActionResult> List(int page, CrewmateEmailFilterViewModel model)
        {
            if (page < 1)
            {
                return NotFound();
            }

            int minDepressionLevel = model?.MinDepressionLevel ?? 0;
            int maxDepressionLevel = model?.MaxDepressionLevel ?? 5;
            var emails = await this._crewmateEmails.GetFilteredAsync(page, PageSize, minDepressionLevel, maxDepressionLevel);

            TempData["PathAndQuery"] = "/Admin/Emails/List/1" + HttpContext.Request.QueryString.Value;

            return View(new CrewmateEmailPageViewModel()
            {
                Emails = emails,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this._crewmateEmails.Total / (double)PageSize),
                MinDepressionLevel = model?.MinDepressionLevel,
                MaxDepressionLevel = model?.MaxDepressionLevel
            });
        }

        [HttpPost]
        [Route("Emails/List/{page}")]
        public async Task<IActionResult> List(int page, CrewmateEmailFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            await this._crewmateEmails.CreateAsync(model.AddText, model.AddMinDepressionLevel, model.AddMaxDepressionLevel);

            return Redirect(TempData["PathAndQuery"].ToString());
        }

        [Route("Emails/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            return await this.EditDeleteEmail(id);
        }

        [HttpPost]
        [Route("Emails/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, CrewmateEmailFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this._crewmateEmails.EditAsync(id, model.AddText, model.AddMinDepressionLevel, model.AddMaxDepressionLevel);

            return Redirect("/Admin/Emails/List/1");
        }

        [Route("Emails/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await this.EditDeleteEmail(id);
        }

        [Route("Emails/Destroy/{id}")]
        public async Task<IActionResult> Destroy(int id)
        {
            await this._crewmateEmails.DeleteAsync(id);

            return Redirect("/Admin/Emails/List/1");
        }

        private async Task<IActionResult> EditDeleteEmail(int id)
        {
            var email = await this._crewmateEmails.GetByIdAsync(id);
            if (email == null)
            {
                return NotFound();
            }

            return View(new CrewmateEmailFormViewModel()
            {
                Id = id,
                AddText = email.Text,
                AddMinDepressionLevel = email.MinDepressionLevel,
                AddMaxDepressionLevel = email.MaxDepressionLevel
            });
        }
    }
}