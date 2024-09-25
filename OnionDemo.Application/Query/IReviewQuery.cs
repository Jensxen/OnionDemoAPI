using OnionDemo.Application.Query.QueryDto;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Query;

public interface IReviewQuery
{
    ReviewDto AddReview(ReviewDto review);
    IEnumerable<Review> GetReviewsByAccommodationId(int id);
}