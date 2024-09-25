using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Application.IRepository;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Command;

public class ReviewCommand
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _uow;
    private readonly IBookingRepository _bookingRepository;

    public ReviewCommand(IReviewRepository reviewRepository, IUnitOfWork uow, IBookingRepository bookingRepository)
    {
        _reviewRepository = reviewRepository;
        _bookingRepository = bookingRepository;
        _uow = uow;
    }

    public void AddReview(AddReviewDto addReviewDto)
    {
        try
        {
            _uow.BeginTransaction();
            var pastBookings = _bookingRepository.GetPastBookings(addReviewDto.Id);
            if (!pastBookings.Any(b => b.AccommodationId == addReviewDto.AccommodationId))
            {
                throw new InvalidOperationException("Guest has not stayed at this accommodation");
            }
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