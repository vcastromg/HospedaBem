using System.Globalization;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HexagonalArchitecture.Pages;

public class HotelModel : PageModel
{
    private readonly HotelService _hotelService;
    public Hotel? Hotel { get; set; }
    public string MapUrl { get; set; }
    public DateTime? CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }

    public HotelModel(HotelService hotelService)
    {
        _hotelService = hotelService;
    }
    
    public IActionResult OnGet(long id, string? checkIn, string? checkOut)
    {
        Hotel = _hotelService.GetHotelById(id);
        
        if (Hotel == null)
        {
            return NotFound();
        }

        if (checkIn != null)
        {
            var decodedCheckIn = System.Web.HttpUtility.UrlDecode(checkIn);
            CheckIn = DateTime.Parse(decodedCheckIn);
        }

        if (checkOut != null)
        {
            var decodedCheckOut = System.Web.HttpUtility.UrlDecode(checkOut);
            CheckOut = DateTime.Parse(decodedCheckOut);
        }

        Hotel.Rooms = _hotelService.GetAvailableRoomsInHotel(id.ToString(), CheckIn, CheckOut);
        
        var latitude = Hotel.Address.Latitude;
        var longitude = Hotel.Address.Longitude;
        var mapBbox = $"{(longitude - 0.005).ToString(CultureInfo.InvariantCulture)},{(latitude - 0.005).ToString(CultureInfo.InvariantCulture)},{(longitude + 0.005).ToString(CultureInfo.InvariantCulture)},{(latitude + 0.005).ToString(CultureInfo.InvariantCulture)}";
        MapUrl = $"https://www.openstreetmap.org/export/embed.html?bbox={mapBbox}&layer=mapnik&marker={latitude.ToString(CultureInfo.InvariantCulture)}%2C{longitude.ToString(CultureInfo.InvariantCulture)}";
        return Page();
    }
}