using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Transactions;
using TravelExperienceCoreAPI.Data;
using TravelExperienceCoreAPI.DTOs;
using TravelExperienceCoreAPI.Models;

namespace TravelExperienceCoreAPI.Services
{
    public class TravelExperienceService : ITravelExperienceService
    {
        private TravelExperienceDbContext _dbContext;
        public TravelExperienceService(TravelExperienceDbContext dbContext)
        {
            _dbContext = dbContext;
        }       


        public async Task<ResponseDTO> AddNewExperience(RequestDTO userrequest)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                //Create new trip            
                var trip = new Trip
                {
                    Title = userrequest.Title,
                    UserId = userrequest.User,
                    StartDate = userrequest.StartDate,
                    EndDate = userrequest.EndDate,
                    TotalCost = userrequest.Activities.Sum(x => x.Cost)
                };

                //Insert new trip
                _dbContext.Trips.Add(trip);
                await _dbContext.SaveChangesAsync();

                //Create new activities
                var activities = userrequest.Activities.Select(a=>new Activity
                {                    
                    DestinationId=a.DestinationId,
                    Duration=a.Duration,
                    Cost=a.Cost,
                    TripId=trip.TripId
                }).ToList();

                

                //Insert new activities
                _dbContext.Activities.AddRange(activities);
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();


                //Create new respone
                var response = new ResponseDTO {
                TripDetails = trip,
                Activities = activities,
                };
                return response;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        
    }
}
