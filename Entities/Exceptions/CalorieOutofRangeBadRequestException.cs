namespace Entities.Exceptions
{
    public abstract partial class BadRequestException
    {
        public class CalorieOutofRangeBadRequestException : BadRequestException
        {
            public CalorieOutofRangeBadRequestException() : base("Maximum calorie should be less than 20000 and gretaer than 0.")
            {

            }
        }
    }
}