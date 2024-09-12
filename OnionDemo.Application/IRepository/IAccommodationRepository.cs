using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Repository;

public interface IAccommodationRepository
{
    Accommodation GetAccommodation(int id);
    void AddAccommodation(Accommodation accommodation);
    void UpdateAccommodation(Accommodation accommodation, byte[] rowversion);
    IEnumerable<Accommodation> getOtherAccommodations();
    void DeleteAccommodation(Accommodation accommodation, byte[] rowversion);
}