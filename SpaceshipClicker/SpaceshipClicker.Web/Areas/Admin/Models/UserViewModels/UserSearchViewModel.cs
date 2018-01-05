namespace SpaceshipClicker.Web.Areas.Admin.Models.UserViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserSearchViewModel
    {
        [Display(Name = "Username")]
        public string SearchUsername { get; set; }
    }
}