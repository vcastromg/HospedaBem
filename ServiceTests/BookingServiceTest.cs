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
        bookingRepositoryMock.Setup(repo => repo.GetBookingsByRoomId(roomId)).Returns(new List<Booking>());

        var result = bookingService.CheckRoomAvailabilityWithinPeriod(roomId, DateTime.Now, DateTime.Now);
    }

    [Fact]
    public void CheckRoomAvailabilityWithinPeriod_ShouldReturnFalse_IfRoomHasCheckInWithinPeriod()
    {
        var bookingRepositoryMock = new Mock<BookingRepository>();
        var roomServiceMock = new Mock<RoomService>();
        var userServiceMock = new Mock<AppUserService>();

        var bookingService = new BookingServiceImp(bookingRepositoryMock.Object, roomServiceMock.Object,
                                                   userServiceMock.Object, this.userManagerMock.Object);

        long roomId = 1;
        var booking = new Booking
        {
            CheckIn = new DateTime(2000, 01, 02),
            CheckOut = new DateTime(2000, 01, 04),
            Room = new Room { Id = roomId },
            User = new IdentityUser()
        };
        bookingRepositoryMock.Setup(repo => repo.GetBookingsByRoomId(roomId)).Returns(new List<Booking>() { booking });

        var result = bookingService.CheckRoomAvailabilityWithinPeriod(roomId, new DateTime(2000, 01, 01), new DateTime(2000, 01, 03));
        Assert.False(result);
    }

    [Fact]
    public void CheckRoomAvailabilityWithinPeriod_ShouldReturnFalse_IfRoomHasCheckOutWithinPeriod()
    {
        var bookingRepositoryMock = new Mock<BookingRepository>();
        var roomServiceMock = new Mock<RoomService>();
        var userServiceMock = new Mock<AppUserService>();

        var bookingService = new BookingServiceImp(bookingRepositoryMock.Object, roomServiceMock.Object,
                                                   userServiceMock.Object, this.userManagerMock.Object);

        long roomId = 1;
        var booking = new Booking
        {
            CheckIn = new DateTime(2000, 01, 01),
            CheckOut = new DateTime(2000, 01, 03),
            Room = new Room { Id = roomId },
            User = new IdentityUser()
        };
        bookingRepositoryMock.Setup(repo => repo.GetBookingsByRoomId(roomId)).Returns(new List<Booking>() { booking });

        var result = bookingService.CheckRoomAvailabilityWithinPeriod(roomId, new DateTime(2000, 01, 02), new DateTime(2000, 01, 04));
        Assert.False(result);
    }

    [Fact]
    public void CheckRoomAvailabilityWithinPeriod_ShouldReturnTrue_IfRoomHasBookingWithCheckInOnQueryCheckOut()
    {
        var bookingRepositoryMock = new Mock<BookingRepository>();
        var roomServiceMock = new Mock<RoomService>();
        var userServiceMock = new Mock<AppUserService>();

        var bookingService = new BookingServiceImp(bookingRepositoryMock.Object, roomServiceMock.Object,
                                                   userServiceMock.Object, this.userManagerMock.Object);

        long roomId = 1;
        var booking = new Booking
        {
            CheckIn = new DateTime(2000, 01, 02),
            CheckOut = new DateTime(2000, 01, 03),
            Room = new Room { Id = roomId },
            User = new IdentityUser()
        };
        bookingRepositoryMock.Setup(repo => repo.GetBookingsByRoomId(roomId)).Returns(new List<Booking>() { booking });

        var result = bookingService.CheckRoomAvailabilityWithinPeriod(roomId, new DateTime(2000, 01, 01), new DateTime(2000, 01, 02));
        Assert.True(result);
    }

    [Fact]
    public void CheckRoomAvailabilityWithinPeriod_ShouldReturnTrue_IfRoomHasBookingWithCheckOutOnQueryCheckIn()
    {
        var bookingRepositoryMock = new Mock<BookingRepository>();
        var roomServiceMock = new Mock<RoomService>();
        var userServiceMock = new Mock<AppUserService>();

        var bookingService = new BookingServiceImp(bookingRepositoryMock.Object, roomServiceMock.Object,
                                                   userServiceMock.Object, this.userManagerMock.Object);

        long roomId = 1;
        var booking = new Booking
        {
            CheckIn = new DateTime(2000, 01, 01),
            CheckOut = new DateTime(2000, 01, 02),
            Room = new Room { Id = roomId },
            User = new IdentityUser()
        };
        bookingRepositoryMock.Setup(repo => repo.GetBookingsByRoomId(roomId)).Returns(new List<Booking>() { booking });

        var result = bookingService.CheckRoomAvailabilityWithinPeriod(roomId, new DateTime(2000, 01, 02), new DateTime(2000, 01, 03));
        Assert.True(result);
    }

    [Fact]
    public void CheckRoomAvailabilityWithinPeriod_ShouldThrowException_IfCheckInIsNotBeforeCheckOut()
    {
        var bookingRepositoryMock = new Mock<BookingRepository>();
        var roomServiceMock = new Mock<RoomService>();
        var userServiceMock = new Mock<AppUserService>();

        var bookingService = new BookingServiceImp(bookingRepositoryMock.Object, roomServiceMock.Object,
                                                   userServiceMock.Object, this.userManagerMock.Object);

        Assert.Throws<ArgumentException>(() => bookingService.CheckRoomAvailabilityWithinPeriod(1, new DateTime(2000, 01, 02), new DateTime(2000, 01, 01)));
    }
}