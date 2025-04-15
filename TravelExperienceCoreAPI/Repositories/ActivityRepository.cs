using TravelExperienceCoreAPI.Data;
using TravelExperienceCoreAPI.Interfaces;
using TravelExperienceCoreAPI.Models;

namespace TravelExperienceCoreAPI.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private TravelExperienceDbContext _dbContext;
        public ActivityRepository(TravelExperienceDbContext dbContext)
        {
            _dbContext = dbContext;
        }        

        public async Task<List<Activity>> AddActivityList(List<Activity> activitlist)
        {
            _dbContext.Activities.AddRange(activitlist);
            await _dbContext.SaveChangesAsync();
            return activitlist;
        }
    }
}
