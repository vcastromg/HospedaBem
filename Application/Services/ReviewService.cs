using Domain;

namespace Application.Services;

public interface ReviewService
{
    public void CreateReview(Review review);
    public ICollection<Review> GetReviewsByUser(string userId);
    public Review UpdateReview(Review review);
    public void DeleteReview(long id);
}