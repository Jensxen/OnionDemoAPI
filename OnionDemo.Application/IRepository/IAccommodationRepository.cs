using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Repository;

public interface IAccommodationRepository
{
    Accommodation GetAccommodation(int id);
    Accommodation GetAccomodationWithBooking(int id);
    void AddAccommodation(Accommodation accommodation);
    void UpdateAccommodation(Accommodation accommodation, byte[] rowVersion);
    void DeleteAccommodation(Accommodation accommodation, byte[] rowVersion);
    void AddBooking(Accommodation booking);
    void UpdateBooking(Accommodation booking, byte[] rowVersion);
    void DeleteBooking(Accommodation booking, byte[] rowVersion);
}