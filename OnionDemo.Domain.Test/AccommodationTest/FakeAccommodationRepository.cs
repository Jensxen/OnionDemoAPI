using OnionDemo.Application.IRepository;
using OnionDemo.Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using OnionDemo.Application.Repository;

namespace OnionDemo.Domain.Test.BookingTests.Fakes
{
    public class FakeAccommodationRepository : IAccommodationRepository
    {
        private readonly List<Accommodation> _accommodations = new List<Accommodation>();

        public Accommodation GetAccommodation(int id)
        {
            return _accommodations.SingleOrDefault(a => a.Id == id);
        }

        public Accommodation GetAccomodationWithBooking(int id)
        {
            throw new NotImplementedException();
        }

        public void AddAccommodation(Accommodation accommodation)
        {
            _accommodations.Add(accommodation);
        }

        public void UpdateAccommodation(Accommodation accommodation, byte[] rowVersion)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccommodation(Accommodation accommodation, byte[] rowVersion)
        {
            throw new NotImplementedException();
        }

        // Add other methods as needed
    }
}