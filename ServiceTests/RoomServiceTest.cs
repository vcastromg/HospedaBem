using Application.Repositories;
using Application.Services;
using Application.Services.Implementations;
using Domain.Entities;
using DTOs;
using Moq;

namespace ServiceTests;

public class RoomServiceTest
{
    [Fact]
    public void RegisterRoom_ShouldCreateAndReturnRoom_WhenHotelExists()
    {
        var roomRepositoryMock = new Mock<RoomRepository>();
        var hotelServiceMock = new Mock<HotelService>();

        var roomService = new RoomServiceImp(roomRepositoryMock.Object, hotelServiceMock.Object);
        
        hotelServiceMock.Setup(service => service.GetHotelById(It.IsAny<string>()))
            .Returns(new Hotel());
        roomRepositoryMock.Setup(repo => repo.Add(It.IsAny<Room>()))
            .Callback((Room room) => { });

        var room = roomService.RegisterRoom(new RegisterRoomDTO());
        
        roomRepositoryMock.Verify(repo => repo.Add(room), Times.Once());
        Assert.IsType<Room>(room);
    }

    [Fact]
    public void FindRoomById_ShouldReturnRoom_WhenRoomExists()
    {
        var roomRepositoryMock = new Mock<RoomRepository>();
        var hotelServiceMock = new Mock<HotelService>();

        var roomService = new RoomServiceImp(roomRepositoryMock.Object, hotelServiceMock.Object);

        long roomId = 1;
        var existingRoom = new Room { Id = roomId };
        roomRepositoryMock.Setup(repo => repo.GetById(roomId))
            .Returns(existingRoom);

        var room = roomService.FindRoomById(roomId.ToString());
        
        Assert.NotNull(room);
        Assert.Equal(room, existingRoom);
    }

    [Fact]
    public void FindRoomById_ShouldThrowException_WhenRoomDoesNotExist()
    {
        var roomRepositoryMock = new Mock<RoomRepository>();
        var hotelServiceMock = new Mock<HotelService>();

        var roomService = new RoomServiceImp(roomRepositoryMock.Object, hotelServiceMock.Object);

        roomRepositoryMock.Setup(repo => repo.GetById(It.IsAny<object>()))
            .Callback((object roomId) => { });

        Assert.Throws<Exception>(() => roomService.FindRoomById("0"));
    }
}