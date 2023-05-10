using Filmoon.Entities;
using Filmoon.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Filmoon.WebAPI.Controllers;

[Route("WebAPI/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Customer")]
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
        return Ok(await RentalsService.GetByCustomerIdAsync(Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier))));
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync([FromBody] RentalEntity rental)
    {
        rental.CustomerId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

        var actionResponse = await RentalsService.AddAsync(rental);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromBody] RentalEntity rental)
    {
        var actionResponse = await RentalsService.UpdateAsync(rental);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> RemoveAsync([FromRoute] int id)
    {
        var actionResponse = await RentalsService.RemoveAsync(id);

        return actionResponse.Succeeded ? Ok(actionResponse) : BadRequest(actionResponse);
    }
}