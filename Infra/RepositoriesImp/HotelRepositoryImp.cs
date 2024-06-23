using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Implementations;

public class HotelRepositoryImp : BaseRepositoryImp<Hotel>, HotelRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public HotelRepositoryImp(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public ICollection<string> GetLastRegisteredHotelNames()
    {
        return Query()
            .AsNoTracking()
            .OrderByDescending(q => q.CreatedAt)
            .Select(q => q.Name)
            .ToList();
    }

    public ICollection<Hotel> GetHotelsByRate(double rate)
    {
        return Query()
            .AsNoTracking()
            .Where(q => q.Rate >= rate)
            .OrderByDescending(q => q.Rate)
            .ToList();
    }

    public ICollection<Room> GetRoomsAvailableInHotel(long hotelId)
    {
        return _applicationDbContext.Hotels
            .Where(hotel => hotel.Id == hotelId)
            .SelectMany(hotel => hotel.Rooms)
            .Where(room => room.IsAvailable)
            .ToList();
    }

    public Hotel GetHotelByPosition(int position)
    {
        return _applicationDbContext.Hotels
            .Include(q => q.Address)
            .Skip(position)
            .Take(1)
            .First();
    }
}