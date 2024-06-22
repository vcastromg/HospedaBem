using Application.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Implementations;

public class ReviewRepositoryImp : BaseRepositoryImp<Review>, ReviewRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ReviewRepositoryImp(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public ICollection<Review> GetReviewsByUser(string userId)
    {
        return Query()
            .AsNoTracking()
            .Where(q => q.User.Id == userId)
            .ToList();
    }

    public Review UpdateReview(Review updatedReview)
    {
        var review = _applicationDbContext.Reviews.Find(updatedReview.Id);

        review.Pros = updatedReview.Pros;
        review.Cons = updatedReview.Cons;
        review.Rate = updatedReview.Rate;

        _applicationDbContext.SaveChanges();

        return review;
    }
}