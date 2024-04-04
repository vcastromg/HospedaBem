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
    
    public ICollection<string> GetLastRegisteredHotelNames()
    {
        return _hotelRepository
            .Query()
            .AsNoTracking()
            .OrderByDescending(q => q.CreatedAt)
            .Select(q => q.Name)
            .ToList();
    }
}