using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HexagonalArchitecture.Pages;

public class HotelModel : PageModel
{
    private readonly HotelService _hotelService;
    public Hotel? Hotel;

    public HotelModel(HotelService hotelService)
    {
        _hotelService = hotelService;
    }
    
    public IActionResult OnGet(long id)
    {
        Hotel = _hotelService.GetHotelById(id);
        if (Hotel == null)
        {
            return NotFound();
        }

        return Page();
    }
}