using Filmoon.Entities;
using Filmoon.Responses;
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
        return Ok(await DirectorsService.GetAsync());
    }

    [HttpPost]
    public async Task<ActionResult<ActionResponse>> AddAsync([FromBody] DirectorEntity director)
    {
        var actionResponse = await DirectorsService.AddAsync(director);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }

    [HttpPut]
    public async Task<ActionResult<ActionResponse>> UpdateAsync([FromBody] DirectorEntity director)
    {
        var actionResponse = await DirectorsService.UpdateAsync(director);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ActionResponse>> RemoveAsync([FromRoute] int id)
    {
        var actionResponse = await DirectorsService.RemoveAsync(id);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }
}
