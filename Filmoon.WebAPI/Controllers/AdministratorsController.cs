using Filmoon.Entities;
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

    [HttpGet]
    public async Task<ActionResult<List<AdministratorEntity>>> GetAsync()
    {
        return Ok(await AdministratorsService.GetAsync());
    }

    [HttpPost]
    public async Task<ActionResult<ActionResponse>> AddAsync(SignUpRequest signUpRequest)
    {
        var actionResponse = await AdministratorsService.AddAsync(signUpRequest);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }
}
