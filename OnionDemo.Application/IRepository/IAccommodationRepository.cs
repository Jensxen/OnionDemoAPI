using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Repository;

public interface IAccommodationRepository
{
    Accommodation GetAccommodation(int id);
    void AddAccommodation(Accommodation accommodation);
    void UpdateAccommodation(Accommodation accommodation, byte[] rowversion);
    void DeleteAccommodation(Accommodation accommodation, byte[] rowversion);
    void DeleteAccommodation(int id);
}