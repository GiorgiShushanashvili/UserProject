using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProjectTosend.Domain.DTOs;
using UserProjectTosend.Domain.Exceptions;
using UserProjectToSend.Apliaction.AbstractionServices;

namespace UserProjectToSend.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost(nameof(UserRegistration))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> UserRegistration([FromBody] UserDTOToAdd userdtoToAdd)
    {
        try
        {
            await _userService.Registration(userdtoToAdd);
            return Created("", "Registration Successful");
        }
        catch (UserAlreadyExistsException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, "An error eccurred");
        }
    }

    [HttpPut(nameof(UserUpdate))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> UserUpdate(UserDTOToUpdate userDTOToUpdate)
    {
        try
        {
            await _userService.UpdateUserAsync(userDTOToUpdate);
            return Ok("User Profile Updated");
        }
        catch (NoUsersException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "an error occured");
        }
    }

    [HttpDelete(nameof(DeleteUser))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            await _userService.DeleteUserAsync(id);
            return Ok("Deleted");
        }
        catch (NoUsersException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, "an error occured");
        }
    }
}
