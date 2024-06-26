using Application.Services;
using Domain;
using Domain.Entities;
using DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HexagonalArchitecture.Pages;

public class BookingsModel : PageModel
{
    private readonly BookingService _bookingService;
    private readonly UserManager<AppUser> _userManager;
    public IEnumerable<Booking>? Bookings { get; set; }

    public BookingsModel(BookingService bookingService, UserManager<AppUser> userManager)
    {
        _bookingService = bookingService;
        _userManager = userManager;
    }
    
    public async Task<IActionResult> OnGet()
    {
        if (HttpContext.User.Identity == null)
        {
            return NotFound();
        }

        var currentUser = await _userManager.GetUserAsync(HttpContext.User);
        Bookings = _bookingService.FindBookingsByUser(currentUser!.Id);

        return Page();
    }
    
    public async Task<IActionResult> OnPost(long roomId, DateTime checkIn, DateTime checkOut)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        var dto = new CreateBookingDTO
        {
            UserId = user!.Id,
            CheckIn = checkIn,
            CheckOut = checkOut,
            RoomId = roomId.ToString()
        };
        
        _bookingService.Book(dto);
        
        var currentUser = await _userManager.GetUserAsync(HttpContext.User);
        Bookings = _bookingService.FindBookingsByUser(currentUser!.Id);

        return Page();
    }
}