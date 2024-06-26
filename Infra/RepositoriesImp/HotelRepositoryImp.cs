using Application.Repositories;
using Domain.Entities;
using DTOs;
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
            .Include(q => q.Rooms)
            .Skip(position)
            .Take(1)
            .First();
    }

    public Hotel? GetHotelByIdForPage(long id)
    {
        return _applicationDbContext.Hotels
            .Include(q => q.Rooms)
            .Include(q => q.Address)
            .Include(q => q.Manager)
            .AsNoTracking()
            .FirstOrDefault(q => q.Id == id);

    }

    public IEnumerable<Hotel> Search(HotelSearchDto dto)
    {
        var query = _applicationDbContext.Hotels
            .AsNoTracking()
            .Include(q => q.Rooms)
            .Include(q => q.Address)
            .AsQueryable();
        if (dto.MinimumRate != null)
        {
            query = query.Where(q => q.Rate >= dto.MinimumRate);
        }

        if (dto.MinimumPrice != null)
        {
            query = query.Where(q => q.Rooms!.Any(r => r.Price >= dto.MinimumPrice));
        }

        if (dto.MaximumPrice != null)
        {
            query = query.Where(q => q.Rooms!.Any(r => r.Price <= dto.MaximumPrice));
        }

        if (dto.CityName != null)
        {
            query = query.Where(q => q.Address.City.Contains(dto.CityName));
        }

        return query.ToList();
    }
}