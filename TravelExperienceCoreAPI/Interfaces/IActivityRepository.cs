using TravelExperienceCoreAPI.Models;

namespace TravelExperienceCoreAPI.Interfaces
{
    public interface IActivityRepository
    {
        Task<List<Activity>> AddActivityList(List<Activity> activitlist);

    }
}
