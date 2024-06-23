using Application.Services;
using Domain.Entities;
using DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HexagonalArchitecture.Pages;

public class IndexModel : PageModel
{
    private readonly HotelService _hotelService;
    public IndexModel(HotelService hotelService)
    {
        _hotelService = hotelService;
    }
    public string? CitySearch { get; set; }
    public IEnumerable<Hotel>? HotelResults { get; set; }
    
    public void OnGet(string? city)
    {
        var search = new HotelSearchDto
        {
            CityName = city
        };
        
        if(!string.IsNullOrWhiteSpace(city))
        {
            CitySearch = city;
        }
        
        HotelResults = _hotelService.Search(search);
    }
}