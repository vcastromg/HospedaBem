using Application.Repositories;
using Domain;
using DTOs;

namespace Application.Services.Implementations;

public class ReviewServiceImp : ReviewService
{
    private readonly ReviewRepository _reviewRepository;
    private readonly AppUserService _appUserService;

    public ReviewServiceImp(ReviewRepository reviewRepository, AppUserService appUserService)
    {
        _reviewRepository = reviewRepository;
        _appUserService = appUserService;
    }

    public void CreateReview(CreateReviewDTO review)
    {
        if (review.Rate > 5)
        {
            throw new Exception("Invalid rate. Must be between 0 and 5");
        }

        var user = _appUserService.FindById(review.UserId);
        //ToDo: consultar o booking a partir do Id passado na request
        // var booking = _bookingService.FindById(review.BookingId); 

        var newReview = new Review(
            review.Pros,
            review.Cons,
            review.Rate,
            null,
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

    public void DeleteReview(long id)
    {
        var existingReview = _reviewRepository.GetById(id);
        if (existingReview != null)
        {
            _reviewRepository.Delete(id);
        }
        
        throw new Exception("Review not found");
    }
}