using Domain.Entities;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementations;

public class HotelServiceImp : HotelService
{
    private readonly HotelRepository _hotelRepository;

    public HotelServiceImp(HotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public IEnumerable<Hotel> GetAllHotels()
    {
        return _hotelRepository.GetAll();
    }
    
    public ICollection<string> GetLastRegisteredHotelNames()
    {
        return _hotelRepository.GetLastRegisteredHotelNames();
    }

    public void RegisterHotel(Hotel hotel)
    {
        var newHotel = new Hotel(hotel.Name, hotel.Address, hotel.Latitude, hotel.Longitude, new List<Room>());
        _hotelRepository.Add(newHotel);
    }
}