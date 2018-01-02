namespace SpaceshipClicker.Web.Infrastructure.Attributes
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class ReviewStarsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            float stars = float.Parse(value.ToString());
            for (float i = GlobalConstants.MinStars; i <= GlobalConstants.MaxStars; i += GlobalConstants.IntervalStars)
            {
                if (stars == i)
                {
                    return true;
                }
            }

            return false;
        }
    }
}