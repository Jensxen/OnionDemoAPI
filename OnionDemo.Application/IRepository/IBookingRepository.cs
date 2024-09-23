using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetBookings();
        Booking GetBooking(int id);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking, byte[] rowVersion);
        void DeleteBooking(Booking booking, byte[] rowVersion);
    }
}
