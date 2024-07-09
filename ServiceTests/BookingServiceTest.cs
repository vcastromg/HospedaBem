using Application.Repositories;
using Application.Services;
using Application.Services.Implementations;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace ServiceTests;

public class BookingServiceTest
{
    [Fact]
    public void CheckRoomAvailabilityWithinPeriod_ShouldReturnTrue_IfThereAreNoBookings()
    {
        var bookingRepositoryMock = new Mock<BookingRepository>();
        var roomServiceMock = new Mock<RoomService>();
        var userServiceMock = new Mock<AppUserService>();

        var store = new Mock<IUserStore<AppUser>>();
        var userManagerMock = new Mock<UserManager<AppUser>>(store.Object, null, null, null, null, null, null, null, null); // What on earth is this?!

        var bookingService = new BookingServiceImp(bookingRepositoryMock.Object, roomServiceMock.Object,
                                                   userServiceMock.Object, userManagerMock.Object);
        long roomId = 1;
        var room = new Room { Id = roomId };
        bookingRepositoryMock.Setup(repo => repo.GetBookingsByRoomId(roomId)).Returns(new List<Booking>());

        var result = bookingService.CheckRoomAvailabilityWithinPeriod(roomId, DateTime.Now, DateTime.Now);
    }
}