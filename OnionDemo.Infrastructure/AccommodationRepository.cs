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

        public Accommodation GetAccommodation(int id)
        {
            return _context.Accommodations
                .Include(a => a.Bookings)
                .FirstOrDefault(a => a.Id == id);
        }

        public void AddAccommodation(Accommodation accommodation)
        {
            _context.Accommodations.Add(accommodation);
            _context.SaveChanges();
        }

        public void UpdateAccommodation(Accommodation accommodation, byte[] rowversion)
        {
            _context.Accommodations.Update(accommodation);
            _context.SaveChanges();
        }

        public IEnumerable<Accommodation> getOtherAccommodations()
        {
            return _context.Accommodations
                .Include(a => a.Bookings)
                .ToList();
        }

        public void DeleteAccommodation(int id, byte[] rowversion)
        {
            var accommodation = _context.Accommodations.Find(id);
            if (accommodation != null)
            {
                _context.Accommodations.Remove(accommodation);
                _context.SaveChanges();
            }
        }

        public Accommodation GetAccommodationById(int id)
        {
            return _context.Accommodations
                .Include(a => a.Bookings)
                .FirstOrDefault(a => a.Id == id);
        }

        public void DeleteAccommodation(int id)
        {
            var accommodation = _context.Accommodations.Find(id);
            if (accommodation != null)
            {
                _context.Accommodations.Remove(accommodation);
                _context.SaveChanges();
            }
        }
    }
}