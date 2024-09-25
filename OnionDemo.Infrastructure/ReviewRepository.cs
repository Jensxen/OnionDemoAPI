using OnionDemo.Application.IRepository;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure;

public class ReviewRepository : IReviewRepository
{
    private readonly List<Review> _reviews = new List<Review>();
    void IReviewRepository.AddReview(Review review)
    {
        _reviews.Add(review);
    }

    public IEnumerable<Review> GetReviewsByAccommodationId(int accommodationId)
    {
        return _reviews.Where(r => r.AccommodationId == accommodationId).ToList();
    }
}