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
public class GenresController : ControllerBase
{
    public GenresController(GenresService genresService)
    {
        GenresService = genresService;
    }

    private GenresService GenresService { get; }

    [HttpGet]
    public async Task<ActionResult<List<GenreEntity>>> GetAsync()
    {
        return await GenresService.GetAsync();
    }

    [HttpPost]
    public async Task<ActionResult<ActionResponse>> AddAsync([FromBody] GenreEntity genre)
    {
        var actionResponse = await GenresService.AddAsync(genre);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }

    [HttpPut]
    public async Task<ActionResult<ActionResponse>> UpdateAsync([FromBody] GenreEntity genre)
    {
        var actionResponse = await GenresService.UpdateAsync(genre);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ActionResponse>> RemoveAsync([FromRoute] int id)
    {
        var actionResponse = await GenresService.RemoveAsync(id);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }
}
