using Domain.Entities;
using DTOs;

namespace Application.Services;

public interface HotelService
{
    IEnumerable<Hotel> GetAllHotels();
    Hotel GetHotelById(string id);
    IEnumerable<Hotel>? GetRandomHotels(int quantity);
    ICollection<string> GetLastRegisteredHotelNames();
    void RegisterHotel(CreateHotelDTO dto);
    bool RemoveHotelById(long hotelId);
    IEnumerable<Hotel> GetRoomsByHotelId(long hotelId);
    ICollection<Hotel> GetHotelsByRate(string rate);
    ICollection<Room> GetAvailableRoomsInHotel(string hotelId);
}