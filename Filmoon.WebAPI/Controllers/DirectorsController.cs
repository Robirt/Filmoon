using Filmoon.Entities;
using Filmoon.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filmoon.WebAPI.Controllers;

[Route("WebAPI/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
[ApiController]
public class DirectorsController : ControllerBase
{
    public DirectorsController(DirectorsService directorsService)
    {
        DirectorsService = directorsService;
    }

    private DirectorsService DirectorsService { get; }

    [HttpGet]
    public async Task<ActionResult<List<DirectorEntity>>> GetAsync()
    {
        return Ok(await DirectorsService.)
    }
}
