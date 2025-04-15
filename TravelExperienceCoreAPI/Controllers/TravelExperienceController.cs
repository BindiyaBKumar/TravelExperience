using Microsoft.AspNetCore.Mvc;
using TravelExperienceCoreAPI.DTOs;
using TravelExperienceCoreAPI.Services;
//using System.Web.Http;

namespace TravelExperienceCoreAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class TravelExperienceController : ControllerBase
    {
        private readonly ITravelExperienceService _travelExperienceService;

        public TravelExperienceController(ITravelExperienceService travelExperienceService)
        {
            _travelExperienceService = travelExperienceService;
        }
        

        [HttpPost("trips")]
        public async Task<IActionResult> AddNewExperience([FromBody] RequestDTO userrequest)
        {
            if (userrequest == null || !ModelState.IsValid)
            {
                return BadRequest("The request is empty");
            }
            else
            {                
                var result = await _travelExperienceService.AddNewExperience(userrequest);
                return Ok(result);
            }
        }
    }
}
