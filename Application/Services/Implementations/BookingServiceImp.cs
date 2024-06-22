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

    public void CancelBooking(long bookingId)
    {
        var booking = _bookingRepository.GetById(bookingId);
        
        if (booking == null)
        {
            throw new ArgumentException("Booking not found");
        }
        else
        {
            _bookingRepository.Delete(booking);
        }
    }

    public bool CheckRoomAvailabilityWithinPeriod(int roomId, DateTime checkIn, DateTime checkOut)
    {
        if(checkIn >= checkOut)
        {
            throw new ArgumentException("Check in date should be strictly before check out date");
        }

        ICollection<Booking> roomBookings = _bookingRepository.GetBookingsByRoomId(roomId);
        foreach (Booking roomBooking in roomBookings)
        {
            if(roomBooking.CheckIn < checkOut && roomBooking.CheckOut > checkIn)
            {
                return false;
            }
        }
        return true;
    }
}
