using Application.Repositories;
using Domain;

namespace Application.Services.Implementations;

public class ReviewServiceImp : ReviewService
{
    private readonly ReviewRepository _reviewRepository;

    public void CreateReview(Review review)
    {
        if (review.Rate > 5)
        {
            throw new Exception("Invalid rate. Must be between 0 and 5");
        }

        _reviewRepository.Add(review);
    }

    public ReviewServiceImp(ReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public ICollection<Review> GetReviewsByUser(string userId)
    {
        return _reviewRepository.GetReviewsByUser(userId);
    }

    public Review UpdateReview(Review review)
    {
        var existingReview = _reviewRepository.GetById(review.Id);
        if (existingReview != null)
        {
            return _reviewRepository.UpdateReview(review);
        }

        throw new Exception("Review not found");
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