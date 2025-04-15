using TravelExperienceCoreAPI.Models;

namespace TravelExperienceCoreAPI.Interfaces
{
    public interface ITripRepository
    {
        Task<Trip> AddTrip(Trip trip);
    }
}
