namespace SpaceshipClicker.Web.Areas.Game.Models
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class UserSpaceshipNameViewModel
    {
        [MinLength(GlobalConstants.SpaceshipNameMinLength)]
        [MaxLength(GlobalConstants.SpaceshipNameMaxLength)]
        public string SpaceshipName { get; set; }
    }
}