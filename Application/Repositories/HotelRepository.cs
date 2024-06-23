using Domain.Entities;
using DTOs;

namespace Application.Repositories;

public interface HotelRepository: BaseRepository<Hotel>
{
    public ICollection<string> GetLastRegisteredHotelNames();
    public ICollection<Hotel> GetHotelsByRate(double rate);
    public ICollection<Room> GetRoomsAvailableInHotel(string hotelName);
    public Hotel GetHotelByPosition(int position);
    public Hotel? GetHotelByIdForPage(long id);
    public IEnumerable<Hotel> Search(HotelSearchDto dto);
}