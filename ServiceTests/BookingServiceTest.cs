using Application.Repositories;
using Application.Services;
using Application.Services.Implementations;
using Domain;
using Domain.Entities;
using DTOs;
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

    [Fact]
    public void Book_ShouldThrowException_WhenRoomIsNotAvailableWithinPeriod()
    {
        var bookingRepositoryMock = new Mock<BookingRepository>();
        var roomServiceMock = new Mock<RoomService>();
        var userServiceMock = new Mock<AppUserService>();

        var bookingService = new BookingServiceImp(bookingRepositoryMock.Object, roomServiceMock.Object,
                                                   userServiceMock.Object, this.userManagerMock.Object);

        var room = new Room { Id = 1 };
        var booking = new Booking
        {
            CheckIn = new DateTime(2000, 01, 01),
            CheckOut = new DateTime(2000, 01, 02),
            Room = room,
            User = new IdentityUser()
        };
        bookingRepositoryMock.Setup(repo => repo.GetBookingsByRoomId(room.Id))
            .Returns(new List<Booking>() { booking });
        roomServiceMock.Setup(sv => sv.FindRoomById(room.Id.ToString()))
            .Returns(room);
        userServiceMock.Setup(sv => sv.FindById("1")).Returns(new IdentityUser() );

        var createBookingDto = new CreateBookingDTO {
            CheckIn = new DateTime(2000, 01, 01),
            CheckOut = new DateTime(2000, 01, 02),
            UserId = "1",
            RoomId = room.Id.ToString()
        };
        Assert.Throws<Exception>(() => bookingService.Book(createBookingDto));
    }

    [Fact]
    public void Book_ShouldCreateAndAddBooking_WhenRoomIsAvailable()
    {
        var bookingRepositoryMock = new Mock<BookingRepository>();
        var roomServiceMock = new Mock<RoomService>();
        var userServiceMock = new Mock<AppUserService>();

        var bookingService = new BookingServiceImp(bookingRepositoryMock.Object, roomServiceMock.Object,
                                                   userServiceMock.Object, this.userManagerMock.Object);

        var room = new Room { Id = 1 };
        bookingRepositoryMock.Setup(repo => repo.GetBookingsByRoomId(room.Id))
            .Returns(new List<Booking>());
        bookingRepositoryMock.Setup(repo => repo.Add(It.IsAny<Booking>()))
            .Callback(() => { });
        roomServiceMock.Setup(sv => sv.FindRoomById(room.Id.ToString()))
            .Returns(room);
        userServiceMock.Setup(sv => sv.FindById("1")).Returns(new IdentityUser());


        var createBookingDto = new CreateBookingDTO
        {
            CheckIn = new DateTime(2000, 01, 01),
            CheckOut = new DateTime(2000, 01, 02),
            UserId = "1",
            RoomId = room.Id.ToString()
        };
        bookingService.Book(createBookingDto);
        bookingRepositoryMock.Verify(repo => repo.Add(It.IsAny<Booking>()), Times.Once());
    }

    [Fact]
    public void CancelBooking_ShouldThrowException_WhenBookingIsNotFound()
    {
        var bookingRepositoryMock = new Mock<BookingRepository>();
        var roomServiceMock = new Mock<RoomService>();
        var userServiceMock = new Mock<AppUserService>();

        var bookingService = new BookingServiceImp(bookingRepositoryMock.Object, roomServiceMock.Object,
                                                   userServiceMock.Object, this.userManagerMock.Object);

        bookingRepositoryMock.Setup(repo => repo.GetById(It.IsAny<long>())).Returns((Booking)null);

        Assert.Throws<Exception>(() => bookingService.CancelBooking(1));
    }

    [Fact]
    public void CancelBooking_ShouldDeleteBookingFromRepo_WhenBookingExists()
    {
        var bookingRepositoryMock = new Mock<BookingRepository>();
        var roomServiceMock = new Mock<RoomService>();
        var userServiceMock = new Mock<AppUserService>();

        var bookingService = new BookingServiceImp(bookingRepositoryMock.Object, roomServiceMock.Object,
                                                   userServiceMock.Object, this.userManagerMock.Object);

        var existentBooking = new Booking();
        bookingRepositoryMock.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(existentBooking);

        bookingService.CancelBooking(1);
        bookingRepositoryMock.Verify(repo => repo.Delete(existentBooking), Times.Once());
    }
}