using DataGeneration;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Controllers;

public class DebugController : ControllerBase
{
    private readonly Generator _generator;
    public DebugController(Generator generator)
    {
        _generator = generator;
    }
    
    [HttpGet("PopulateDb")]
    public IActionResult Index()
    {
        _generator.GenerateHotels(1000);
        return Ok();
    }
}