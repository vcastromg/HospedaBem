using Domain.Entities;

namespace Application.Repositories;

public interface HotelRepository: BaseRepository<Hotel>
{
    public ICollection<string> GetLastRegisteredHotelNames();
    public ICollection<Hotel> GetHotelsByRate(double rate);
    public ICollection<Room> GetRoomsAvailableInHotel(string hotelName);
    public Hotel GetHotelByPosition(int position);
}