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
    void UpdateHotelCoverImage(long hotelId, string imageUrl);
    ICollection<Hotel> GetHotelsByRate(string rate);
    ICollection<Room> GetAvailableRoomsInHotel(string hotelId, DateTime? checkIn, DateTime? checkOut);
    Hotel? GetHotelById(long id);
    IEnumerable<Hotel> Search(HotelSearchDto dto);
}