using Microsoft.EntityFrameworkCore;
using TravelExperienceCoreAPI.Models;

namespace TravelExperienceCoreAPI.Data
{
    public class TravelExperienceDbContext : DbContext
    {
        public TravelExperienceDbContext(DbContextOptions<TravelExperienceDbContext> options):base(options){ }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Trip> Trips { get; set; }
    }
}
