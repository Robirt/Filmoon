using Filmoon.Requests;
using Filmoon.Responses;
using Filmoon.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filmoon.WebAPI.Controllers;

[Route("WebAPI/[controller]")]
[AllowAnonymous]
[ApiController]
public class UsersController : ControllerBase
{
    public UsersController(UsersService usersService)
    {
        UsersService = usersService;
    }

    private UsersService UsersService { get; }

    [HttpPost("SignIn")]
    public async Task<ActionResult<SignInResponse>> SignInAsync([FromBody] SignInRequest signInRequest)
    {
        var actionResponse = await UsersService.SignInAsync(signInRequest);

        return actionResponse.Succeeded ? Ok(actionResponse) : Unauthorized(actionResponse);
    }
}
