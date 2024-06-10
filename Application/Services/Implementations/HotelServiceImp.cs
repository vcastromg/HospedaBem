using Application.Repositories;
using Domain.Entities;

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
        var newHotel = new Hotel(hotel.Name, new List<Room>());
        _hotelRepository.Add(newHotel);
    }

    public IEnumerable<Hotel> GetRoomsByHotelId(long hotelId)
    {
        throw new NotImplementedException();
    }

    public ICollection<Hotel> GetHotelsByRate(string rate)
    {
        return _hotelRepository.GetHotelsByRate(double.Parse(rate));
    }
}