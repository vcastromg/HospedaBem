using Domain.Entities;

namespace Application.Services;

public interface HotelService
{
    IEnumerable<Hotel> GetAllHotels();
    ICollection<string> GetLastRegisteredHotelNames();
    void RegisterHotel(Hotel hotel);
    IEnumerable<Hotel> GetRoomsByHotelId(long hotelId);
    ICollection<Hotel> GetHotelsByRate(string rate);
}