using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HexagonalArchitecture.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly HotelService _hotelService;
    
    public IEnumerable<string> LastHotels;

    public IndexModel(ILogger<IndexModel> logger, HotelService hotelService)
    {
        _hotelService = hotelService;
        _logger = logger;
    }

    public void OnGet()
    {
        LastHotels = _hotelService.GetLastRegisteredHotelNames();
    }
}