﻿using Application.Repositories;
using Domain;
using DTOs;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.Implementations;

public class BookingServiceImp : BookingService
{
    private readonly BookingRepository _bookingRepository;
    private readonly RoomService _roomService;
    private readonly AppUserService _userService;
    private readonly UserManager<AppUser> _userManager;

    public BookingServiceImp(BookingRepository bookingRepository, RoomService roomService, AppUserService userService, UserManager<AppUser> userManager)
    {
        _bookingRepository = bookingRepository;
        _roomService = roomService;
        _userService = userService;
        _userManager = userManager;
    }

    public void Book(CreateBookingDTO dto)
    {
        var room = _roomService.FindRoomById(dto.RoomId);
        var user = _userService.FindById(dto.UserId);

        if (!CheckRoomAvailabilityWithinPeriod(room.Id, dto.CheckIn, dto.CheckOut))
        {
            throw new Exception($"The room is not available from {dto.CheckIn} to {dto.CheckOut}");
        }

        var booking = new Booking
        {
            CheckIn = dto.CheckIn,
            CheckOut = dto.CheckOut,
            Comment = dto.Comment,
            User = user,
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
        var booking = FindBookingById(bookingId.ToString());

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
        var booking = _bookingRepository.GetBookingById(long.Parse(id));
        if (booking == null)
        {
            throw new Exception("Booking not found");
        }

        return booking;
    }

    public IEnumerable<Booking> FindBookingsByUser(string userId)
    {
        return _bookingRepository.GetBookingsbyUser(userId);
    }
}