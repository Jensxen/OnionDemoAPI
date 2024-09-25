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
            return _context.Accommodations.FirstOrDefault(a => a.Id == id);
        }

        IEnumerable<Accommodation> IAccommodationRepository.GetAccommodationsByHostId(int hostId)
        {
            return _context.Accommodations
                .Include(a => a.Reviews)
                .Where(a => a.HostId == hostId)
                .ToList();
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

        public void AddBooking(Accommodation booking)
        {
            _context.SaveChanges();
        }

        public void UpdateBooking(Accommodation booking, byte[] rowVersion)
        {
            _context.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowVersion;
            _context.SaveChanges();
        }

        public void DeleteBooking(Accommodation booking, byte[] rowVersion)
        {
            _context.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowVersion;
            _context.SaveChanges();
        }
    }
}