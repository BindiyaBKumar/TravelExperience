using TravelExperienceCoreAPI.DTOs;
using TravelExperienceCoreAPI.Models;

namespace TravelExperienceCoreAPI.Services
{
    public interface ITravelExperienceService
    {        
        Task<ResponseDTO> AddNewExperience(RequestDTO userrequest);
    }
}
