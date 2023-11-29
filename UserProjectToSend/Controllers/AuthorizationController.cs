using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProjectTosend.Domain.DTOs;
using UserProjectTosend.Domain.Exceptions;
using UserProjectToSend.Apliaction.AbstractionServices;

namespace UserProjectToSend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorizationController : ControllerBase
{
    private readonly IAuthorizationService _authorizService;
    public AuthorizationController(IAuthorizationService authorizationService)
    {
        _authorizService = authorizationService;
    }

    [HttpPost(nameof(LoginUser))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> LoginUser([FromBody] userForLoginDTO userLoginData)
    {
        try
        {
            var token = await _authorizService.Login(userLoginData);
            return Ok(new { token });
        }
        catch (IncorrectPasswordException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, "an error occured");
        }
    }
}
