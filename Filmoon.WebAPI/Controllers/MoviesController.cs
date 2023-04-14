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
    public async Task<ActionResult> AddAsync([FromBody] MovieEntity movie)
    {
        try
        {
            await MoviesService.AddAsync(movie);
            return NoContent();
        }

        catch
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] MovieEntity movie)
    {
        try
        {
            await MoviesService.UpdateAsync(movie);
            return NoContent();
        }

        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> RemoveAsync([FromRoute] int id)
    {
        try
        {
            await MoviesService.RemoveAsync(id);
            return NoContent();
        }

        catch
        {
            return BadRequest();
        }
    }
}
