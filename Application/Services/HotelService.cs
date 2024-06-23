using Domain.Entities;

namespace Application.Services;

public interface HotelService
{
    IEnumerable<Hotel> GetAllHotels();
    IEnumerable<Hotel>? GetRandomHotels(int quantity);
    ICollection<string> GetLastRegisteredHotelNames();
    void RegisterHotel(Hotel hotel);
    bool RemoveHotelById(long hotelId);
    IEnumerable<Hotel> GetRoomsByHotelId(long hotelId);
    ICollection<Hotel> GetHotelsByRate(string rate);
    ICollection<Room> GetAvailableRoomsInHotel(string hotelName);
    Hotel? GetHotelById(long id);
}