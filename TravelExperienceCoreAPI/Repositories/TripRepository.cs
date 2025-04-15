using TravelExperienceCoreAPI.Data;
using TravelExperienceCoreAPI.Interfaces;
using TravelExperienceCoreAPI.Models;

namespace TravelExperienceCoreAPI.Repositories
{
        public class TripRepository : ITripRepository
        {
            private TravelExperienceDbContext _dbContext;
            public TripRepository(TravelExperienceDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Trip> AddTrip(Trip trip)
            {
                _dbContext.Trips.Add(trip);
                await _dbContext.SaveChangesAsync();
                return trip;
            }

        }
    
}
