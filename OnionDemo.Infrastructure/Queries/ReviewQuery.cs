using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Query.QueryDto;

namespace OnionDemo.Infrastructure.Queries;

public class ReviewQuery
{
    private readonly BookMyHomeContext _db;

    public ReviewQuery(BookMyHomeContext db)
    {
        _db = db;
    }
    ReviewDto? GetReview(int id)
    {
        var review = _db.Reviews.AsNoTracking().Single(a => a.Id == id);
        return new ReviewDto
        {
            Id = review.Id,
            Comment = review.Comment,
            Rating = review.Rating,
            RowVersion = review.RowVersion
        };
    }

    IEnumerable<ReviewDto> GetReviews()
    {
        var result = _db.Reviews.AsNoTracking().Select(a => new ReviewDto
        {
            Id = a.Id,
            Comment = a.Comment,
            Rating = a.Rating,
            RowVersion = a.RowVersion
        });
        return result;
    }

}