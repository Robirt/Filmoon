using Filmoon.Entities;
using Filmoon.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filmoon.WebAPI.Controllers;

[Route("WebAPI/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
public class RentalsController : ControllerBase
{
    public RentalsController(RentalsService rentalsService)
    {
        RentalsService = rentalsService;
    }

    private RentalsService RentalsService { get; }

    [HttpGet]
    public async Task<ActionResult<List<RentalEntity>>> GetAsync()
    {
        return Ok(await RentalsService.GetAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RentalEntity>> GetByIdAsync([FromRoute] int id)
    {
        return Ok(await RentalsService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync([FromBody] RentalEntity rental)
    {
        try
        {
            await RentalsService.AddAsync(rental);
            return NoContent();
        }

        catch
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] RentalEntity rental)
    {
        try
        {
            await RentalsService.UpdateAsync(rental);
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
            await RentalsService.RemoveAsync(id);
            return NoContent();
        }

        catch
        {
            return BadRequest();
        }
    }
}