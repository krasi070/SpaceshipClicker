namespace SpaceshipClicker.Web.Areas.Admin.Models.CrewmateNameViewModels
{
    using Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class CrewmateNameFormViewModel
    {
        [Display(Name = "Name")]
        public string SearchName { get; set; }

        [Display(Name = "Name")]
        public string AddName { get; set; }

        [Display(Name = "Race")]
        public Race AddRace { get; set; }

        [Display(Name = "Gender")]
        public Gender AddGender { get; set; }
    }
}