using OnionDemo.Application.IRepository;
using OnionDemo.Application.Repository;
using OnionDemo.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnionDemo.Domain.Test.BookingTests.Fakes
{
    public class FakeAccommodationRepository : IAccommodationRepository
    {
        public FakeAccommodation(int id, int hostId)
            : base(id, hostId)
        {
        }

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
    }
}


