using OnionDemo.Domain.Entity;

namespace OnionDemo.Domain.DomainServices;

public interface IAccommodationDomainService
{
    IEnumerable<Accommodation> getOtherAccommodations(Accommodation accommodation);
}