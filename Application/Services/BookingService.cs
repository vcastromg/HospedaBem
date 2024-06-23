using Domain;
using Domain.Entities;
using DTOs;

namespace Application.Services;

public interface BookingService
{
    void Book(CreateBookingDTO dto);
    void CancelBooking(long bookingId);
    bool CheckRoomAvailabilityWithinPeriod(long roomId, DateTime checkIn, DateTime checkOut);
    Booking FindBookingById(string id);
}