namespace SpaceshipClicker.Web.Models.ReviewViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FilterViewModel
    {
        [Display(Name = "Minimum Stars")]
        public float? MinStars { get; set; }

        [Display(Name = "Maximum Stars")]
        public float? MaxStars { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }
}