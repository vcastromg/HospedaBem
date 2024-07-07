using System;
using Xunit;
using Moq;
using Application.Services.Implementations;
using Application.Repositories;
using Domain.Entities;
using DTOs;

namespace ServiceTests;

public class HotelServiceTest
{
    [Fact]
    public void GetHotelById_ShouldReturnCorrectHotel()
    {
        // Arrange
        var hotelId = "1";
        var mockRepository = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(mockRepository.Object);

        mockRepository.Setup(repo => repo.GetById(It.IsAny<long>()))
            .Returns((long id) => new Hotel { Id = id, Name = "Hotel Test" });

        // Act
        var result = hotelService.GetHotelById(hotelId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Hotel Test", result.Name);
    }

    [Fact]
    public void GetHotelById_ShouldThrowException_WhenHotelNotFound()
    {
        // Arrange
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        var hotelId = "-1";

        hotelRepositoryMock.Setup(repo => repo.GetById(It.IsAny<long>()))
            .Returns((long id) => null);

        // Act e Assert
        Assert.Throws<Exception>(() => hotelService.GetHotelById(hotelId));
    }

    [Fact]
    public void GetAllHotels_ShouldReturnAllHotels()
    {
        // Arrange
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        var hotels = new List<Hotel>
        {
            new() { Id = 1, Name = "Hotel A" },
            new() { Id = 2, Name = "Hotel B" }
        };

        hotelRepositoryMock.Setup(repo => repo.GetAll())
            .Returns(hotels);

        // Act
        var result = hotelService.GetAllHotels();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(hotels.Count, result.Count());
    }

    [Fact]
    public void GetLastRegisteredHotelNames_ShouldReturnNames()
    {
        // Arrange
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        var hotelNames = new List<string>
        {
            "Hotel A",
            "Hotel B"
        };

        hotelRepositoryMock.Setup(repo => repo.GetLastRegisteredHotelNames())
            .Returns(hotelNames);

        // Act
        var result = hotelService.GetLastRegisteredHotelNames();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(hotelNames.Count, result.Count());
    }

    [Fact]
    public void RegisterHotel_ShouldAddNewHotel()
    {
        // Arrange
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        var dto = new CreateHotelDTO
        {
            Name = "Novo Hotel",
            Rate = 4.5,
            CoverImageUrl = "https://example.com/hotel-image.jpg"
        };

        // Act
        hotelService.RegisterHotel(dto);

        // Assert
        hotelRepositoryMock.Verify(repo => repo.Add(It.IsAny<Hotel>()), Times.Once);
    }
    
    [Fact]
    public void RemoveHotelById_ShouldDeleteHotel_WhenHotelExists()
    {
        // Arrange
        var hotelId = 1L;
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        var existingHotel = new Hotel { Id = hotelId, Name = "Existing Hotel" };
        
        hotelRepositoryMock.Setup(repo => repo.GetById(hotelId))
            .Returns(existingHotel);

        // Act
        var result = hotelService.RemoveHotelById(hotelId);

        // Assert
        Assert.True(result);
        hotelRepositoryMock.Verify(repo => repo.Delete(existingHotel), Times.Once);
    }

    [Fact]
    public void RemoveHotelById_ShouldReturnFalse_WhenHotelDoesNotExist()
    {
        // Arrange
        var hotelId = 2L;
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        
        hotelRepositoryMock.Setup(repo => repo.GetById(hotelId))
            .Returns((Hotel)null);

        // Act
        var result = hotelService.RemoveHotelById(hotelId);

        // Assert
        Assert.False(result);
        hotelRepositoryMock.Verify(repo => repo.Delete(It.IsAny<Hotel>()), Times.Never);
    }
}