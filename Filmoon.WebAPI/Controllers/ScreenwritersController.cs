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
public class ScreenwritersController : ControllerBase
{
    public ScreenwritersController(ScreenwritersService screenwritersService)
    {
        ScreenwritersService = screenwritersService;
    }

    private ScreenwritersService ScreenwritersService { get; }

    [HttpGet]
    public async Task<ActionResult<List<ScreenwriterEntity>>> GetAsync()
    {
        return Ok(await ScreenwritersService.GetAsync());
    }

    [HttpPost]
    public async Task<ActionResult<ActionResponse>> AddAsync([FromBody] ScreenwriterEntity screenwriter)
    {
        var actionResponse = await ScreenwritersService.AddAsync(screenwriter);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }

    [HttpPut]
    public async Task<ActionResult<ActionResponse>> UpdateAsync([FromBody] ScreenwriterEntity screenwriter)
    {
        var actionResponse = await ScreenwritersService.UpdateAsync(screenwriter);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ActionResponse>> RemoveAsync([FromRoute] int id)
    {
        var actionResponse = await ScreenwritersService.RemoveAsync(id);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }
}
