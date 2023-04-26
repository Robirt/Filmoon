using Filmoon.Entities;
using Filmoon.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filmoon.WebAPI.Controllers;

[Route("WebAPI/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
public class MoviesController : ControllerBase
{
    public MoviesController(MoviesService moviesService)
    {
        MoviesService = moviesService;
    }

    private MoviesService MoviesService { get; }

    [HttpGet]
    public async Task<ActionResult<List<MovieEntity>>> GetAsync()
    {
        return Ok(await MoviesService.GetAsync());
    }

    [HttpGet("{title:string}")]
    public async Task<ActionResult<MovieEntity>> GetByTitleAsync([FromRoute] string title)
    {
        return Ok(await MoviesService.GetByTitleAsync(title));
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> AddAsync([FromBody] MovieEntity movie)
    {
        var actionResponse = await MoviesService.AddAsync(movie);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }

    [HttpPut]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> UpdateAsync([FromBody] MovieEntity movie)
    {
        var actionResponse = await MoviesService.UpdateAsync(movie);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> RemoveAsync([FromRoute] int id)
    {
        var actionResponse = await MoviesService.RemoveAsync(id);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }
}
