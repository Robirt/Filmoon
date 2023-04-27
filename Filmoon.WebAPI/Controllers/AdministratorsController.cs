using Filmoon.Requests;
using Filmoon.Responses;
using Filmoon.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filmoon.WebAPI.Controllers;

[Route("WebAPI/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
[ApiController]
public class AdministratorsController : ControllerBase
{
    public AdministratorsController(AdministratorsService administratorsService)
    {
        AdministratorsService = administratorsService;
    }

    private AdministratorsService AdministratorsService { get; }

    [HttpPost]
    public async Task<ActionResult<ActionResponse>> AddAsync(SignUpRequest userSignUpRequest)
    {
        var actionResponse = await AdministratorsService.AddAsync(userSignUpRequest);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }
}
