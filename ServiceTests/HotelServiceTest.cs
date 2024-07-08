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
    
    [Fact]
    public void UpdateHotelCoverImage_ShouldUpdateCoverImageUrl_WhenHotelExists()
    {
        // Arrange
        var hotelId = 1L;
        var imageUrl = "https://example.com/hotel-image.jpg";
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        var existingHotel = new Hotel { Id = hotelId, Name = "Existing Hotel", CoverImageUrl = "old-image-url" };
        
        hotelRepositoryMock.Setup(repo => repo.GetById(hotelId))
            .Returns(existingHotel);

        // Act
        hotelService.UpdateHotelCoverImage(hotelId, imageUrl);

        // Assert
        Assert.Equal(imageUrl, existingHotel.CoverImageUrl);
        hotelRepositoryMock.Verify(repo => repo.Update(existingHotel), Times.Once);
    }

    [Fact]
    public void UpdateHotelCoverImage_ShouldThrowException_WhenHotelDoesNotExist()
    {
        // Arrange
        var hotelId = 2L;
        var imageUrl = "https://example.com/hotel-image.jpg"; 
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        
        hotelRepositoryMock.Setup(repo => repo.GetById(hotelId))
            .Returns((Hotel)null);

        // Act e Assert
        Assert.Throws<Exception>(() => hotelService.UpdateHotelCoverImage(hotelId, imageUrl));
    }
    
    [Fact]
    public void GetHotelsByRate_ShouldReturnHotels()
    {
        // Arrange
        var rate = "4.0";
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        var hotels = new List<Hotel>
        {
            new Hotel { Id = 1L, Name = "Hotel A", Rate = 4.5 },
            new Hotel { Id = 2L, Name = "Hotel B", Rate = 3.8 },
        };
        
        hotelRepositoryMock.Setup(repo => repo.GetHotelsByRate(It.IsAny<double>()))
            .Returns((double r) => hotels.FindAll(h => h.Rate >= r));

        // Act
        var result = hotelService.GetHotelsByRate(rate);

        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public void GetAvailableRoomsInHotel_ShouldReturnRooms()
    {
        // Arrange
        var hotelId = 1L;
        var hotel = new Hotel { Id = 1L, Name = "Hotel Test" };
        var checkIn = DateTime.Now;
        var checkOut = checkIn.AddDays(3);
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        var rooms = new List<Room>
        {
            new Room { Id = 1L, Hotel = hotel, Number = 101 },
            new Room { Id = 2L, Hotel = hotel, Number =102 },
        };
        
        hotelRepositoryMock.Setup(repo => repo.GetRoomsAvailableInHotel(It.IsAny<long>(), It.IsAny<DateTime?>(), It.IsAny<DateTime?>()))
            .Returns((long id, DateTime? ci, DateTime? co) => rooms.FindAll(r => r.Hotel.Id == id && r.IsAvailable));

        // Act
        var result = hotelService.GetAvailableRoomsInHotel("1", checkIn, checkOut);

        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public void GetHotelById_ShouldReturnHotel()
    {
        // Arrange
        var hotelId = 1L; 
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        var existingHotel = new Hotel { Id = hotelId, Name = "Existing Hotel" };
        
        hotelRepositoryMock.Setup(repo => repo.GetHotelByIdForPage(hotelId))
            .Returns(existingHotel);

        // Act
        var result = hotelService.GetHotelById(hotelId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(existingHotel, result);
    }
    
    [Fact]
    public void Search_ShouldReturnHotels()
    {
        // Arrange
        var searchDto = new HotelSearchDto { };
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        var hotels = new List<Hotel>
        {
            new Hotel { Id = 1, Name = "Hotel A" },
            new Hotel { Id = 2, Name = "Hotel B" },
        };
        
        hotelRepositoryMock.Setup(repo => repo.Search(searchDto))
            .Returns(hotels);

        // Act
        var result = hotelService.Search(searchDto);

        // Assert
        Assert.NotNull(result);
    }
    
    [Fact]
    public void GetRandomHotels_ShouldReturnHotels()
    {
        // Arrange
        var quantity = 3;
        var hotelsCount = 10;
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        
        hotelRepositoryMock.Setup(repo => repo.GetHotelByPosition(It.IsAny<int>()))
            .Returns((int index) => new Hotel { Id = index, Name = $"Hotel {index}" });
        
        hotelRepositoryMock.Setup(repo => repo.Count())
            .Returns(hotelsCount);

        // Act
        var result = hotelService.GetRandomHotels(quantity);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(quantity, result.Count());
    }
    
    [Fact]
    public void GetRandomHotels_ShouldReturnNull()
    {
        // Arrange
        var quantity = 3;
        var hotelsCount = 1;
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);
        
        hotelRepositoryMock.Setup(repo => repo.Count())
            .Returns(hotelsCount);

        // Act
        var result = hotelService.GetRandomHotels(quantity);

        // Assert
        Assert.Null(result);
    }
    
    [Fact]
    public void GetRandomHotels_ShouldReturnEmpty()
    {
        // Arrange
        var quantity = 0;
        var hotelRepositoryMock = new Mock<HotelRepository>();
        var hotelService = new HotelServiceImp(hotelRepositoryMock.Object);

        // Act
        var result = hotelService.GetRandomHotels(quantity);

        // Assert
        Assert.Empty(result);
    }
}