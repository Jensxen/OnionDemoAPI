using OnionDemo.Application.Query.QueryDto;

namespace OnionDemo.Application.Command;

public interface IReviewCommand
{
    void AddReview(ReviewDto addReviewDto);
}