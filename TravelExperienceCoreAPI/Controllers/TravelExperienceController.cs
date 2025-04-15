using Microsoft.AspNetCore.Mvc;
using TravelExperienceCoreAPI.DTOs;
using TravelExperienceCoreAPI.Helpers;
using TravelExperienceCoreAPI.Services;
//using System.Web.Http;

namespace TravelExperienceCoreAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class TravelExperienceController : ControllerBase
    {
        private readonly ITravelExperienceService _travelExperienceService;
        private readonly ValidateUserInput _validateUserInput;

        public TravelExperienceController(ITravelExperienceService travelExperienceService, ValidateUserInput validateUserInput)
        {
            _travelExperienceService = travelExperienceService;
            _validateUserInput = validateUserInput;
        }
        

        [HttpPost("trips")]
        public async Task<IActionResult> AddNewExperience([FromBody] RequestDTO userrequest)
        {
            try
            {
                if (userrequest == null)
                {
                    return BadRequest("The request is empty");
                }
                else if (!ModelState.IsValid)
                {
                    return BadRequest("The request is invalid");
                }
                else
                {
                    List<string> error = _validateUserInput.ValidateInput(userrequest);
                    if (error.Count != 0)
                    {
                        return BadRequest(error);
                    }
                    else
                    {
                        var result = await _travelExperienceService.AddNewExperience(userrequest);
                        return Ok(result);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest("An unexpected error has occured.");
            }
        }
    }
}
