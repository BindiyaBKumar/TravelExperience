using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Transactions;
using TravelExperienceCoreAPI.Data;
using TravelExperienceCoreAPI.DTOs;
using TravelExperienceCoreAPI.Interfaces;
using TravelExperienceCoreAPI.Models;

namespace TravelExperienceCoreAPI.Services
{
    public class TravelExperienceService : ITravelExperienceService
    {
        private TravelExperienceDbContext _dbContext;
        private IActivityRepository _activityRepository;
        private ITripRepository _tripRepository;
        public TravelExperienceService(TravelExperienceDbContext dbContext, IActivityRepository activityRepository, ITripRepository tripRepository)
        {
            _dbContext = dbContext;
            _activityRepository = activityRepository;
            _tripRepository = tripRepository;

        }       


        public async Task<ResponseDTO> AddNewExperience(RequestDTO userrequest)
        {
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
                var newTrip = await _tripRepository.AddTrip(trip);

                //Create new activities
                var activities = userrequest.Activities.Select(a=>new Activity
                {                    
                    DestinationId=a.DestinationId,
                    Duration=a.Duration,
                    Cost=a.Cost,
                    TripId=newTrip.TripId
                }).ToList();


                //Insert new activities
                var newactivities = await _activityRepository.AddActivityList(activities);


                //Create new respone
                var response = new ResponseDTO {
                TripDetails = trip,
                Activities = activities,
                };
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        
    }
}
