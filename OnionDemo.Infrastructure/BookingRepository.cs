using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionDemo.Application;
using OnionDemo.Application.Repository;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookMyHomeContext _db;
        
        public BookingRepository(BookMyHomeContext context)
        {
            _db = context;
        }

        void IBookingRepository.AddBooking(Booking booking)
        {
            _db.Bookings.Add(booking);
            _db.SaveChanges();
        }


        public IEnumerable<Booking> GetBookings()
        {
            return _db.Bookings.ToList();
        }

        public IEnumerable<Booking> GetPastBookings(int guestId)
        {
            return _db.Bookings.Where(a => a.GuestId == guestId && a.IsPastBooking()).ToList();
        }

        Booking IBookingRepository.GetBooking(int id)
        {
            return _db.Bookings.Single(a => a.Id == id);
        }

        void IBookingRepository.UpdateBooking(Booking booking, byte[] rowVersion)
        { 
            _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowVersion;
            _db.SaveChanges();
        }

        void IBookingRepository.DeleteBooking(Booking booking, byte[] rowVersion)
        {
            _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowVersion;
            _db.Bookings.Remove(booking);
            _db.SaveChanges();
        }
    }
}
