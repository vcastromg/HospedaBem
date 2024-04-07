using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Controllers;

[ApiController]
[Route("/api")]
[Route("/api/hotel")]
public class HotelController : ControllerBase
{
    [HttpGet]
    public List<Hotel> listHotels()
    {
        Hotel h1 = new Hotel("Hotel1", "address", 4234.32, 4324.32, null);
        Hotel h2 = new Hotel();

        return new List<Hotel>() { h1, h2 };
    }
}