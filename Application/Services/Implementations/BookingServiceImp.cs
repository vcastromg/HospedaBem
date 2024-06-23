using Application.Repositories;
using Domain;
using Domain.Entities;

namespace Application.Services.Implementations;
public class BookingServiceImp : BookingService
{
    private readonly BookingRepository _bookingRepository;
    private readonly RoomRepository _roomRepository;
    private readonly AppUserRepository _userRepository;

    public BookingServiceImp(BookingRepository bookingRepository, RoomRepository roomRepository, AppUserRepository userRepository)
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
        _userRepository = userRepository;
    }

    public void Book(DateTime checkIn, DateTime checkOut, long roomId, long userId)
    {
        var room = _roomRepository.GetById(roomId);
        if (room == null)
        {
            throw new Exception("Room not found");
        }
        
        var user = _userRepository.GetById(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        
        if(!CheckRoomAvailabilityWithinPeriod(room.Id, checkIn, checkOut))
        {
            throw new Exception($"The room is not available from {checkIn} to {checkOut}");
        }

        var booking = new Booking
        {
            CheckIn = checkIn,
            CheckOut = checkOut,
            // User = user,
            Room = room
        };
        _bookingRepository.Add(booking);
    }

    public void CancelBooking(long bookingId)
    {
        var booking = _bookingRepository.GetById(bookingId);
        
        if (booking == null)
        {
            throw new Exception("Booking not found");
        }
        else
        {
            _bookingRepository.Delete(booking);
        }
    }

    public void UpdateBookingPeriod(long bookingId, DateTime checkIn, DateTime checkOut)
    {
        var booking = _bookingRepository.GetById(bookingId);
        if (booking == null)
        {
            throw new Exception("Booking not found");
        }

        if (!CheckRoomAvailabilityWithinPeriod(bookingId, checkIn, checkOut))
        {
            throw new Exception($"The room is not available from {checkIn} to {checkOut}");
        }

        booking.CheckIn = checkIn;
        booking.CheckOut = checkOut;
        _bookingRepository.Update(booking);
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

    public Booking FindBookingById(string id)
    {
        var booking = _bookingRepository.GetById(id);
        if (booking == null)
        {
            throw new Exception("Booking not found");
        }

        return booking;
    }
}
