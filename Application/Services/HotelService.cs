using Domain;

namespace Application.Services;

public interface HotelService
{
    IEnumerable<Room> GetRoomsByHotelId(long hotelId);
    IEnumerable<string> GetLastRegisteredHotelNames();
}