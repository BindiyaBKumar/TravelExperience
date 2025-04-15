using TravelExperienceCoreAPI.Models;

namespace TravelExperienceCoreAPI.DTOs
{
    public class ResponseDTO
    {
        public Trip TripDetails { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
