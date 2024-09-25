using OnionDemo.Application.Command.CommandDto;
using OnionDemo.Application.IRepository;
using OnionDemo.Application.Query.QueryDto;
using OnionDemo.Application.Repository;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Command;

public class ReviewCommand
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _uow;
    private readonly IBookingRepository _bookingRepository;
    private readonly IAccommodationRepository _accommodationRepository;

    public ReviewCommand(IReviewRepository reviewRepository, IUnitOfWork uow, IBookingRepository bookingRepository, IAccommodationRepository accommodationRepository)
    {
        _reviewRepository = reviewRepository;
        _bookingRepository = bookingRepository;
        _accommodationRepository = accommodationRepository;
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

    public IEnumerable<AccommodationDto> GetReviewsForHost(int hostId)
    {
        var accommodations = _accommodationRepository.GetAccommodationsByHostId(hostId);
        var accommodationDtos = accommodations.Select(a => new AccommodationDto()
        {
            Id = a.Id,
            Reviews = a.Reviews.Select(r => new ReviewDto()
            {
                Id = r.Id,
                Comment = r.Comment,
                Rating = r.Rating
            }).ToList()
        }).ToList();
        return accommodationDtos;
    }
}