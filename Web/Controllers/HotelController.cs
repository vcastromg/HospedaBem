

using Application.Services;
using Domain.Entities;
using DTOs;
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
    public CreatedResult RegisterHotel(CreateHotelDTO hotel)
    {
        _hotelService.RegisterHotel(hotel);
        return Created();
    }

    [HttpDelete]
    [Route("/{hotelId}")]
    public IActionResult RemoveHotelById(long hotelId)
    {
        var result = _hotelService.RemoveHotelById(hotelId);
        if(result)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpGet]
    [Route("/rate")]
    public IActionResult ListHotelsByRate([FromQuery]string rate)
    {
        return Ok(_hotelService.GetHotelsByRate(rate));
    }

    // [HttpGet]
    // [Route("/api/hotel/rooms/{id}")]
    // public IActionResult ListAvailableRoomsInHotel([FromRoute] string id)
    // {
    //     return Ok(_hotelService.GetAvailableRoomsInHotel(id));
    // }

    [HttpGet]
    [Route("{id}")]
    public IActionResult FindHotelById([FromRoute] string id)
    {
        return Ok(_hotelService.GetHotelById(id));
    }
}