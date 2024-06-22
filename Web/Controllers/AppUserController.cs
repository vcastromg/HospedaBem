using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Controllers;

[ApiController]
[Route("/api/user")]
public class AppUserController : ControllerBase
{
    private readonly AppUserService _appUserService;

    public AppUserController(AppUserService appUserService)
    {
        _appUserService = appUserService;
    }

    [HttpGet]
    public IActionResult ListUsers()
    {
        return Ok(_appUserService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById([FromRoute] string id)
    {
        return Ok(_appUserService.FindById(id));
    }
}