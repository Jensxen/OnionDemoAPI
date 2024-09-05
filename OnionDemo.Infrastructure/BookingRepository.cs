using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionDemo.Application;
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

        Booking IBookingRepository.GetBooking(int id)
        {
            return _db.Bookings.Single(a => a.Id == id);
        }

        void IBookingRepository.UpdateBooking(Booking booking, byte[] rowversion)
        {
            using (var transaction = _db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    _db.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowversion;
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    transaction.Rollback();

                    var entry = _db.Entry(booking);
                    var databaseEntry = entry.GetDatabaseValues();

                    if (databaseEntry == null)
                    {
                        throw new Exception("The booking was deleted by another user");
                    }
                    else
                    {
                        var databaseValues = (Booking)databaseEntry.ToObject();
                        entry.OriginalValues.SetValues(databaseValues);
                        entry.CurrentValues.SetValues(booking);


                        entry.Property(nameof(booking.RowVersion)).OriginalValue = databaseValues.RowVersion;

                        _db.SaveChanges();
                    }

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }


        }

        public void DeleteBooking(int id)
        {
            using (var transaction = _db.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    var booking = _db.Bookings.Single(a => a.Id == id);
                    if (booking == null)
                    {
                        throw new Exception("Booking not found");
                    }

                    _db.Bookings.Remove(booking);
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Concurrency issue occured while deleting the booking", ex);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("An error occured while deleting booking", ex);
                }
            }
        }
    }
}
