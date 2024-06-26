using Application.Services;
using Domain;
using Domain.Entities;
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
}