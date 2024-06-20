using Domain;

namespace Application.Repositories;

public interface ReviewRepository: BaseRepository<Review>
{
    public ICollection<Review> GetReviewsByUser(string userId);
    public Review UpdateReview(Review updatedReview);
}