namespace SpaceshipClicker.Web.Areas.Admin.Models.ReviewViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReviewEditViewModel : ReviewStatesViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Review")]
        public string Text { get; set; }

        public float Stars { get; set; }

        [Display(Name = "Posted on")]
        public DateTime ReviewedOn { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }
    }
}