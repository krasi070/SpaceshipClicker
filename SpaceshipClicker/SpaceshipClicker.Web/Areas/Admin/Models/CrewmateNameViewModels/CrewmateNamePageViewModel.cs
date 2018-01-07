namespace SpaceshipClicker.Web.Areas.Admin.Models.CrewmateNameViewModels
{
    using Data.Models.Enums;
    using SpaceshipClicker.Services.Models;
    using System.Collections.Generic;

    public class CrewmateNamePageViewModel : CrewmateNameFormViewModel
    {
        public IEnumerable<CrewmateNameModel> Names { get; set; }

        public Race Race { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;
    }
}