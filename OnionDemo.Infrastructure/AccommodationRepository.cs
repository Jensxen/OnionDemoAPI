using OnionDemo.Application.Repository;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure;

public class AccommodationRepository : IAccommodationRepository
{
    private readonly BookMyHomeContext _db;

    public AccommodationRepository(BookMyHomeContext context)
    {
        _db = context;
    }

    Accommodation IAccommodationRepository.GetAccommodation(int id)
    {
        return _db.Accommodations.Single(a => a.Id == id);
    }

    void IAccommodationRepository.AddAccommodation(Accommodation accommodation)
    {
        _db.Accommodations.Add(accommodation);
        _db.SaveChanges();
    }

    void IAccommodationRepository.UpdateAccommodation(Accommodation accommodation, byte[] rowversion)
    {
        
    }

    public void DeleteAccommodation(Accommodation accommodation, byte[] rowversion)
    {
        throw new NotImplementedException();
    }

    void IAccommodationRepository.DeleteAccommodation(int id)
    {
        throw new NotImplementedException();
    }
}