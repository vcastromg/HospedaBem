using Domain;
using DTOs;

namespace Application.Services;

public interface ReviewService
{
    public void CreateReview(CreateReviewDTO review);
    public IList<Review> GetReviewsByUser(string userId);
    public Review UpdateReview(UpdateReviewDTO review);
    public void DeleteReview(string id);
}