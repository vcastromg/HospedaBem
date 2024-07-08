using Application.Repositories;
using Application.Services;
using Application.Services.Implementations;
using Domain;
using DTOs;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace ServiceTests;

public class ReviewServiceTest
{
    [Fact]
    public void CreateReview_ShouldAddNewReview()
    {
        var reviewRepositoryMock = new Mock<ReviewRepository>();
        var appUserServiceMock = new Mock<AppUserService>();
        var bookingServiceMock = new Mock<BookingService>();
        var reviewService = new ReviewServiceImp(reviewRepositoryMock.Object, appUserServiceMock.Object,
            bookingServiceMock.Object);
        var reviewDto = new CreateReviewDTO
        {
            UserId = "1",
            BookingId = "101",
            Pros = "Good service",
            Cons = "Expensive",
            Rate = 4
        };

        appUserServiceMock.Setup(service => service.FindById(It.IsAny<string>()))
            .Returns(new IdentityUser { Id = reviewDto.UserId });
        bookingServiceMock.Setup(service => service.FindBookingById(It.IsAny<string>()))
            .Returns(new Booking { });

        reviewService.CreateReview(reviewDto);

        reviewRepositoryMock.Verify(repo => repo.Add(It.IsAny<Review>()), Times.Once);
    }

    [Fact]
    public void CreateReview_ShouldThrowException_WhenInvalidRate()
    {
        var reviewRepositoryMock = new Mock<ReviewRepository>();
        var appUserServiceMock = new Mock<AppUserService>();
        var bookingServiceMock = new Mock<BookingService>();
        var reviewService = new ReviewServiceImp(reviewRepositoryMock.Object, appUserServiceMock.Object,
            bookingServiceMock.Object);
        var reviewDto = new CreateReviewDTO
        {
            UserId = "1",
            BookingId = "101",
            Pros = "Good service",
            Cons = "Expensive",
            Rate = 6
        };

        Assert.Throws<Exception>(() => reviewService.CreateReview(reviewDto));
    }

    [Fact]
    public void GetReviewsByUser_ShouldReturnReviews()
    {
        var userId = "1";
        var user = new IdentityUser() { };
        var reviewRepositoryMock = new Mock<ReviewRepository>();
        var appUserServiceMock = new Mock<AppUserService>();
        var bookingServiceMock = new Mock<BookingService>();
        var reviewService = new ReviewServiceImp(reviewRepositoryMock.Object, appUserServiceMock.Object,
            bookingServiceMock.Object);
        var reviews = new List<Review>
        {
            new() { Id = 101, User = user, Pros = "Good review", Cons = "Nothing" },
            new() { Id = 102, User = user, Pros = "Another review", Cons = "Something" }
        };

        reviewRepositoryMock.Setup(repo => repo.GetReviewsByUser(userId))
            .Returns(reviews);

        var result = reviewService.GetReviewsByUser(userId);

        Assert.NotNull(result);
        Assert.Equal(reviews.Count, result.Count);
    }

    [Fact]
    public void UpdateReview_ShouldUpdateExistingReview()
    {
        var reviewId = 101;
        var reviewRepositoryMock = new Mock<ReviewRepository>();
        var appUserServiceMock = new Mock<AppUserService>();
        var bookingServiceMock = new Mock<BookingService>();
        var reviewService = new ReviewServiceImp(reviewRepositoryMock.Object, appUserServiceMock.Object,
            bookingServiceMock.Object);
        var existingReview = new Review { Id = reviewId, Pros = "Good review", Cons = "None", Rate = 4 };
        var updatedReviewDto = new UpdateReviewDTO
        {
            Id = reviewId,
            Pros = "Updated pros",
            Cons = "Updated cons",
            Rate = 4
        };
        var updatedReview = new Review { Id = reviewId, Pros = "Updated pros", Cons = "Updated cons", Rate = 4 };
        
        reviewRepositoryMock.Setup(repo => repo.GetById(reviewId))
            .Returns(existingReview);
        reviewRepositoryMock.Setup(repo => repo.UpdateReview(existingReview))
            .Returns(updatedReview);
        
        var result = reviewService.UpdateReview(updatedReviewDto);
        
        Assert.NotNull(result);
        Assert.Equal(updatedReviewDto.Pros, result.Pros);
        Assert.Equal(updatedReviewDto.Cons, result.Cons);
        Assert.Equal(updatedReviewDto.Rate, result.Rate);
        reviewRepositoryMock.Verify(repo => repo.UpdateReview(existingReview), Times.Once);
    }

    [Fact]
    public void UpdateReview_ShouldThrowException_WhenReviewNotFound()
    {
        var reviewId = 102; 
        var reviewRepositoryMock = new Mock<ReviewRepository>();
        var appUserServiceMock = new Mock<AppUserService>();
        var bookingServiceMock = new Mock<BookingService>();
        var reviewService = new ReviewServiceImp(reviewRepositoryMock.Object, appUserServiceMock.Object,
            bookingServiceMock.Object);
        var updatedReviewDto = new UpdateReviewDTO
        {
            Id = reviewId,
            Pros = "Updated pros",
            Cons = "Updated cons",
            Rate = 4
        };
        
        reviewRepositoryMock.Setup(repo => repo.GetById(reviewId))
            .Returns((Review)null);
        
        Assert.Throws<Exception>(() => reviewService.UpdateReview(updatedReviewDto));
    }
    
    [Fact]
    public void DeleteReview_ShouldDeleteExistingReview()
    {
        var reviewId = "101";
        var reviewRepositoryMock = new Mock<ReviewRepository>();
        var appUserServiceMock = new Mock<AppUserService>();
        var bookingServiceMock = new Mock<BookingService>();
        var reviewService = new ReviewServiceImp(reviewRepositoryMock.Object, appUserServiceMock.Object,
            bookingServiceMock.Object);
        var existingReview = new Review { Pros = "Good review", Cons = "None", Rate = 4 };
        
        reviewRepositoryMock.Setup(repo => repo.GetById(reviewId))
            .Returns(existingReview);
        
        reviewService.DeleteReview(reviewId);
        
        reviewRepositoryMock.Verify(repo => repo.Delete(reviewId), Times.Once);
    }

    [Fact]
    public void DeleteReview_ShouldThrowException_WhenReviewNotFound()
    {
        var reviewId = "102";
        var reviewRepositoryMock = new Mock<ReviewRepository>();
        var appUserServiceMock = new Mock<AppUserService>();
        var bookingServiceMock = new Mock<BookingService>();
        var reviewService = new ReviewServiceImp(reviewRepositoryMock.Object, appUserServiceMock.Object,
            bookingServiceMock.Object);
        
        reviewRepositoryMock.Setup(repo => repo.GetById(reviewId))
            .Returns((Review)null);
        
        Assert.Throws<Exception>(() => reviewService.DeleteReview(reviewId));
    }
}