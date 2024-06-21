using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HexagonalArchitecture.Pages;

public class ExploreModel : PageModel
{
    private readonly HotelService _hotelService;

    public ExploreModel(HotelService hotelService)
    {
        _hotelService = hotelService;
    }

    public IEnumerable<Hotel>? RandomHotels { get; set; }
    
    public void OnGet()
    {
        RandomHotels = _hotelService.GetRandomHotels(3);
    }
}