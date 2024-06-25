using Application.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Implementations;

public class BookingRepositoryImp : BaseRepositoryImp<Booking>, BookingRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public BookingRepositoryImp(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public ICollection<Booking> GetBookingsByRoomId(long roomId)
    {
        return _applicationDbContext.Bookings
            .Include(b => b.Room)
            .Where(b => b.Room.Id == roomId)
            .ToList();
    }

    public ICollection<Booking> GetBookingsbyUser(string userId)
    {
        return _applicationDbContext.Bookings
            .Include(b => b.Room)
            .Where(b => b.User.Id == userId)
            .ToList();   
    }
}