using Application.Services;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Controllers;

[ApiController]
[Route("/api/booking")]
public class BookingController : ControllerBase
{
    private readonly BookingService _bookingService;

    public BookingController(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public IActionResult RegisterBooking(CreateBookingDTO dto)
    {
        _bookingService.Book(dto);
        return Created();
    }
}