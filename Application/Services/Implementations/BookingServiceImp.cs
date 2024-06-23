using Application.Repositories;
using Domain;
using Domain.Entities;
using DTOs;

namespace Application.Services.Implementations;

public class BookingServiceImp : BookingService
{
    private readonly BookingRepository _bookingRepository;
    private readonly RoomService _roomService;
    private readonly AppUserService _userService;

    public BookingServiceImp(BookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public void Book(CreateBookingDTO dto)
    {
        var room = _roomService.FindRoomById(dto.RoomId);
        var user = _userService.FindById(dto.UserId);

        if (!CheckRoomAvailabilityWithinPeriod(room.Id, dto.CheckIn, dto.CheckOut))
        {
            throw new Exception($"The room is not available from {dto.CheckIn} to {dto.CheckOut}");
        }

        _bookingRepository.Add(new Booking(dto.CheckIn, dto.CheckOut, (AppUser)user, room));
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

    public bool CheckRoomAvailabilityWithinPeriod(long roomId, DateTime checkIn, DateTime checkOut)
    {
        if (checkIn >= checkOut)
        {
            throw new ArgumentException("Check in date should be strictly before check out date");
        }

        ICollection<Booking> roomBookings = _bookingRepository.GetBookingsByRoomId(roomId);
        foreach (Booking roomBooking in roomBookings)
        {
            if (roomBooking.CheckIn < checkOut && roomBooking.CheckOut > checkIn)
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