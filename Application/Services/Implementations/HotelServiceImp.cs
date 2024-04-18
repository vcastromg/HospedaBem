using Application.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Implementations;

public class HotelServiceImp : HotelService
{
    private readonly HotelRepository _hotelRepository;

    public HotelServiceImp(HotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public IEnumerable<Room> GetRoomsByHotelId(long hotelId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<string> GetLastRegisteredHotelNames()
    {
        return _hotelRepository
            .Query()
            .AsNoTracking()
            .OrderByDescending(q => q.CreatedAt)
            .Select(q => q.Name)
            .ToList();
    }
}