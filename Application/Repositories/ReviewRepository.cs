using Domain;

namespace Application.Repositories;

public interface ReviewRepository: BaseRepository<Review>
{
    public IList<Review> GetReviewsByUser(string userId);
    public Review UpdateReview(Review updatedReview);
}