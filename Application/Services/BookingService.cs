using Domain;

namespace Application.Services;

public interface BookingService
{
    Booking Book(DateTime checkin, DateTime checkout, int roomId);
    void CancelBooking(long bookingId);
}