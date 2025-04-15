using System.Globalization;
using TravelExperienceCoreAPI.DTOs;

namespace TravelExperienceCoreAPI.Helpers
{
    public class ValidateUserInput
    {
        public List<string> ValidateInput(RequestDTO input)
        {
            var errors = new List<string>();
            DateTime parsedDate = new DateTime();

            if (string.IsNullOrWhiteSpace(input.Title))
                errors.Add("Title is required.");

            if (string.IsNullOrWhiteSpace(input.User))
                errors.Add("User is required.");

            if (input.StartDate > input.EndDate)
                errors.Add("Start date cannot be later than end date.");

            if (!DateTime.TryParseExact(input.StartDate.ToShortDateString(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate) ||
               !DateTime.TryParseExact(input.EndDate.ToShortDateString(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                errors.Add("Dates need to be in the format YYYY-MM-DD");

            if (input.StartDate == null || String.IsNullOrEmpty(input.StartDate.ToString()))
                errors.Add("Start date is required.");

            if (input.EndDate == null || String.IsNullOrEmpty(input.EndDate.ToString()))
                errors.Add("End date is required.");

            if (input.Activities.Exists(x => String.IsNullOrEmpty(x.DestinationId)))
                errors.Add("DestinationId is required in all activities");

            if (input.Activities.Exists(x => x.Duration == 0 || x.Duration == null))
                errors.Add("Duration is required in all activities");

            if (input.Activities.Exists(x => x.Cost == 0 || x.Cost == null))
                errors.Add("Cost is required in all activities");

            return errors;
        }
    }
}
