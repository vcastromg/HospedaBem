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
    public DateTime? CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
    public IEnumerable<Hotel>? HotelResults { get; set; }
    
    public void OnGet(string? citySearch, DateTime? checkIn, DateTime? checkOut)
    {
        var search = new HotelSearchDto
        {
            CityName = citySearch,
            MininumDate = CheckIn,
            MaximumDate = CheckOut
        };
        
        HotelResults = _hotelService.Search(search);
        
        if(!string.IsNullOrWhiteSpace(citySearch))
        {
            CitySearch = citySearch;
        }

        CheckIn = checkIn;
        CheckOut = checkOut;
    }
}