using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.IRepository;

public interface IReviewRepository
{
    void AddReview(Review review);
    IEnumerable<Review> GetReviewsByAccommodationId(int id);
}