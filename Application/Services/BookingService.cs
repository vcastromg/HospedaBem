using Domain;
using Domain.Entities;

namespace Application.Services;

public interface BookingService
{
    void Book(DateTime checkIn, DateTime checkOut, long roomId, long userId);
    void CancelBooking(long bookingId);
    void UpdateBookingPeriod(long bookingId, DateTime checkIn, DateTime checkOut);
    bool CheckRoomAvailabilityWithinPeriod(long roomId, DateTime checkIn, DateTime checkOut);
}