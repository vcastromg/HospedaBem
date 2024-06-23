using Application.Repositories;
using Domain;
using Domain.Entities;

namespace Application.Services.Implementations;
public class BookingServiceImp : BookingService
{
    private readonly BookingRepository _bookingRepository;

    public BookingServiceImp(BookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public void Book(DateTime checkIn, DateTime checkOut, Room room, AppUser user)
    {
        if(!CheckRoomAvailabilityWithinPeriod(room.Id, checkIn, checkOut))
        {
            throw new Exception($"The room is not available from {checkIn} to {checkOut}");
        }
        else
        {
            _bookingRepository.Add(new Booking(checkIn, checkOut, user, room));
        }
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

    public void UpdateBookingPeriod(long bookingId, DateTime checkIn, DateTime checkOut)
    {
        if (!CheckRoomAvailabilityWithinPeriod(bookingId, checkIn, checkOut))
        {
            var booking = _bookingRepository.GetById(bookingId);
            if (booking == null)
            {
                throw new Exception("Booking not found");
            }
            booking.CheckIn = checkIn;
            booking.CheckOut = checkOut;
            _bookingRepository.Update(booking);
        }
    }

    public bool CheckRoomAvailabilityWithinPeriod(long roomId, DateTime checkIn, DateTime checkOut)
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
