using Domain;
using Domain.Entities;

namespace Application.Services;

public interface BookingService
{
    void Book(DateTime checkIn, DateTime checkOut, Room room, AppUser user);
    void CancelBooking(long bookingId);
    bool CheckRoomAvailabilityWithinPeriod(long roomId, DateTime checkIn, DateTime checkOut);
}