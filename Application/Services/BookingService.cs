using Domain;
using Domain.Entities;
using DTOs;

namespace Application.Services;

public interface BookingService
{
    void Book(CreateBookingDTO dto);
    void CancelBooking(long bookingId);
    void UpdateBookingPeriod(long bookingId, DateTime checkIn, DateTime checkOut);
    bool CheckRoomAvailabilityWithinPeriod(long roomId, DateTime checkIn, DateTime checkOut);
    Booking FindBookingById(string id);
    IEnumerable<Booking> FindBookingsByUser(string userId);
}