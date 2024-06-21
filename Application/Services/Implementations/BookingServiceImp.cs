using Application.Repositories;
using Domain;

namespace Application.Services.Implementations;
public class BookingServiceImp : BookingService
{
    private readonly BookingRepository _bookingRepository;

    public BookingServiceImp(BookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public Booking Book(DateTime checkin, DateTime checkout, int roomId)
    {
        throw new NotImplementedException();
    }
}
