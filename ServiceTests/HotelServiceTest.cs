using System;
using Xunit;
using Moq;
using Application.Services.Implementations;
using Application.Repositories;
using Domain.Entities;

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
}