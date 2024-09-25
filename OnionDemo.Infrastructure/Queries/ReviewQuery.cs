using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Command;
using OnionDemo.Application.Query;
using OnionDemo.Application.Query.QueryDto;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure.Queries;

public class ReviewQuery : IReviewQuery
{
    private readonly BookMyHomeContext _db;
    private readonly ReviewCommand _reviewCommand;

    public ReviewQuery(BookMyHomeContext db, ReviewCommand reviewCommand)
    {
        _db = db;
        _reviewCommand = reviewCommand;
    }

    public IEnumerable<AccommodationDto> GetAccommodationsByHostId(int hostId)
    {
        var result = _db.Accommodations
            .Where(a => a.HostId == hostId)
            .Select(a => new AccommodationDto
            {
                Id = a.Id,
                HostId = a.HostId,
            });
        return result;
    }
    public int HostId { get; set; }
    public IEnumerable<AccommodationDto> Handle()
    {
        return _reviewCommand.GetReviewsForHost(this.HostId);
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

    public ReviewDto AddReview(ReviewDto review)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Review> GetReviewsByAccommodationId(int id)
    {
        throw new NotImplementedException();
    }
}