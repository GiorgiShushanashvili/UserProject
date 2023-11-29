using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProjectTosend.Domain.Abstractions;
using UserProjectTosend.Domain.DTOs;
using UserProjectTosend.Domain.Exceptions;
using UserProjectToSend.Apliaction.AbstractionServices;

namespace UserProjectToSend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfService;
        public UserProfileController(IUserProfileService userProfService)
        {
            _userProfService = userProfService;
        }

        [HttpGet(nameof(GetAllUserProfiles))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserProfileDTO>>> GetAllUserProfiles()
        {
            try
            {
                var userProfiles = await _userProfService.GetAllUserProfiles();
                return Ok(userProfiles);
            }
            catch (NoUsersException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, "an error occured");
            }
        }

        [HttpGet(nameof(GetUserProfile))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserProfile(int id)
        {
            try
            {
                var user = await _userProfService.GetUserProfileById(id);
                return Ok(user);
            }
            catch (NoUserOnThisNameException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500, "an error occured");
            }
        }
    }
}
