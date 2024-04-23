

using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Controllers;

[ApiController]
[Route("/api/hotel")]
public class HotelController : ControllerBase
{
    private readonly HotelService _hotelService;

    public HotelController(HotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_hotelService.GetAllHotels());
    }

    [HttpGet("ListHotels")]
    public IActionResult ListHotels()
    {
        return Ok(_hotelService.GetAllHotels());
    }

    [HttpPost]
    [Route("/api/hotel")]
    public CreatedResult RegisterHotel(Hotel hotel)
    {
        _hotelService.RegisterHotel(hotel);
        return Created();
    }
}