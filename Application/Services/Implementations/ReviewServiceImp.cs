using Application.Repositories;
using Domain;
using DTOs;

namespace Application.Services.Implementations;

public class ReviewServiceImp : ReviewService
{
    private readonly ReviewRepository _reviewRepository;
    private readonly AppUserService _appUserService;
    private readonly BookingService _bookingService;

    public ReviewServiceImp(ReviewRepository reviewRepository, AppUserService appUserService, BookingService bookingService)
    {
        _reviewRepository = reviewRepository;
        _appUserService = appUserService;
        _bookingService = bookingService;
    }

    public void CreateReview(CreateReviewDTO review)
    {
        if (review.Rate > 5)
        {
            throw new Exception("Invalid rate. Must be between 0 and 5");
        }

        var user = _appUserService.FindById(review.UserId);
        var booking = _bookingService.FindBookingById(review.BookingId);

        var newReview = new Review(
            review.Pros,
            review.Cons,
            review.Rate,
            booking,
            user);

        _reviewRepository.Add(newReview);
    }

    public ICollection<Review> GetReviewsByUser(string userId)
    {
        return _reviewRepository.GetReviewsByUser(userId);
    }

    public Review UpdateReview(UpdateReviewDTO review)
    {
        var existingReview = _reviewRepository.GetById(review.Id);
        
        if (existingReview == null) throw new Exception("Review not found");
        
        existingReview.Cons = review.Cons;
        existingReview.Pros = review.Pros;
        existingReview.Rate = review.Rate;
        return _reviewRepository.UpdateReview(existingReview);
    }

    public void DeleteReview(string id)
    {
        var existingReview = _reviewRepository.GetById(id);
        if (existingReview != null)
        {
            _reviewRepository.Delete(id);
        }
        
        throw new Exception("Review not found");
    }
}