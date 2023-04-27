using Filmoon.Requests;
using Filmoon.Responses;
using Filmoon.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filmoon.WebAPI.Controllers;

[Route("WebAPI/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
public class CustomersController : ControllerBase
{
    public CustomersController(CustomersService customersService)
    {
        CustomersService = customersService;
    }

    private CustomersService CustomersService { get; }

    [HttpPost]
    public async Task<ActionResult<ActionResponse>> SignUpAsync(SignUpRequest userSignUpRequest)
    {
        var actionResponse = await CustomersService.SignUpAsync(userSignUpRequest);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }
}
