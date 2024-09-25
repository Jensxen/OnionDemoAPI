using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Application.IRepository;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Command;

public class ReviewCommand
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _uow;

    public ReviewCommand(IReviewRepository reviewRepository, IUnitOfWork uow)
    {
        _reviewRepository = reviewRepository;
        _uow = uow;
    }

    public void AddReview(AddReviewDto addReviewDto)
    {
        try
        {
            _uow.BeginTransaction();
            var review = Review.Create(addReviewDto.Id, addReviewDto.GuestId, addReviewDto.Comment, addReviewDto.Rating);
            _reviewRepository.AddReview(review);
            _uow.Commit();
        }
        catch (Exception e)
        {
            _uow.Rollback();
            throw;
        }
    }
}