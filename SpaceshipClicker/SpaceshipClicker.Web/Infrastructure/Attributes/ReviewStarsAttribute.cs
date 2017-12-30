namespace SpaceshipClicker.Web.Infrastructure.Attributes
{
    using Constants;
    using System.ComponentModel.DataAnnotations;

    public class ReviewStarsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            float stars = float.Parse(value.ToString());
            for (float i = Constants.MinStars; i <= Constants.MaxStars; i += Constants.IntervalStars)
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