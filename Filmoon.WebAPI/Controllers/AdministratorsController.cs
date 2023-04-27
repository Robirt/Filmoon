using Filmoon.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filmoon.WebAPI.Controllers;

[Route("WebAPI/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
public class AdministratorsController : ControllerBase
{
    public AdministratorsController(AdministratorsService administratorsService)
    {
        AdministratorsService = administratorsService;
    }

    private AdministratorsService AdministratorsService { get; }
}
