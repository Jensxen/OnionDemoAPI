using OnionDemo.Application.Repository;
using OnionDemo.Domain.DomainServices;

namespace OnionDemo.Application.Command;

public class AccommodationCommand : IAcommendationCommand
{
    private readonly IAccommodationRepository _accommodationRepository;
    private readonly IBookingDomainService _domainService;
    private readonly IUnitOfWork _unitOfWork;
}