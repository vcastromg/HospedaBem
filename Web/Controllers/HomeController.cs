using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HexagonalArchitecture.Controllers;

[ApiController]
[Route("/")]
public class HomeController : Controller {
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}