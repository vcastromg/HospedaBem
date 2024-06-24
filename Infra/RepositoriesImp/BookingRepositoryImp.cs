using Application.Repositories;
using Domain;

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
            .Where(b => b.Room.Id == roomId)
            .ToList();
    }
}