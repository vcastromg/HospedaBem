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
    private Mock<UserManager<AppUser>> userManagerMock;

    public BookingServiceTest()
    {
        var store = new Mock<IUserStore<AppUser>>();
        this.userManagerMock = new Mock<UserManager<AppUser>>(store.Object, null, null, null, null, null, null, null, null); // What on earth is this?!
    }

    [Fact]
    public void CheckRoomAvailabilityWithinPeriod_ShouldReturnTrue_IfThereAreNoBookings()
    {
        var bookingRepositoryMock = new Mock<BookingRepository>();
        var roomServiceMock = new Mock<RoomService>();
        var userServiceMock = new Mock<AppUserService>();

        var bookingService = new BookingServiceImp(bookingRepositoryMock.Object, roomServiceMock.Object,
                                                   userServiceMock.Object, this.userManagerMock.Object);
        long roomId = 1;
        var room = new Room { Id = roomId };
        bookingRepositoryMock.Setup(repo => repo.GetBookingsByRoomId(roomId)).Returns(new List<Booking>());

        var result = bookingService.CheckRoomAvailabilityWithinPeriod(roomId, DateTime.Now, DateTime.Now);
    }
}