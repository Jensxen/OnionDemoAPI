using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Repository;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure
{
    public class AccommodationRepository : IAccommodationRepository
    {
        private readonly BookMyHomeContext _context;

        public AccommodationRepository(BookMyHomeContext context)
        {
            _context = context;
        }

        void IAccommodationRepository.AddAccommodation(Accommodation accommodation)
        {
            _context.Accommodations.Add(accommodation);
        }

        Accommodation IAccommodationRepository.GetAccommodation(int id)
        {
            return _context.Accommodations
                .Single(a => a.Id == id);
        }

        Accommodation IAccommodationRepository.GetAccomodationWithBooking(int id)
        {
            return _context.Accommodations
                .Include(a => a.Bookings)
                .FirstOrDefault(a => a.Id == id);
        }

        void IAccommodationRepository.UpdateAccommodation(Accommodation accommodation, byte[] rowVersion)
        {
            _context.Entry(accommodation).Property(nameof(accommodation.RowVersion)).OriginalValue = rowVersion;
            _context.Accommodations.Update(accommodation);
        }

        void IAccommodationRepository.DeleteAccommodation(Accommodation accommodation, byte[] rowVersion)
        {
            _context.Entry(accommodation).Property(nameof(accommodation.RowVersion)).OriginalValue = rowVersion;
            _context.Accommodations.Remove(accommodation);
        }

        public void CreateBooking(DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }
    }
}