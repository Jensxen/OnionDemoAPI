﻿using System.ComponentModel.DataAnnotations;
using OnionDemo.Domain.DomainServices;

namespace OnionDemo.Domain.Entity;

public class Booking : DomainEntity
{


    protected Booking()
    {

    }

    private Booking(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> existingBookings)
    {
        StartDate = startDate;
        EndDate = endDate;

        AssureStartDateBeforeEndDate();
        AssureBookingSkalVæreIFremtiden(DateOnly.FromDateTime(DateTime.Now));
        
    }
    public int GuestId { get; protected set; }
    public int AccommodationId { get; protected set; }
    public DateOnly StartDate { get; protected set; }
    public DateOnly EndDate { get; protected set; }
    //public Accommodation Accommodation { get; protected set; }
    //public Host Host { get; protected set; }

    protected void AssureStartDateBeforeEndDate()
    {
        if (!(StartDate < EndDate)) throw new ArgumentException("StartDato skal være før EndDato");
    }


    protected void AssureBookingSkalVæreIFremtiden(DateOnly now)
    {
        // Booking skal være i fremtiden
        if (StartDate <= now)
            throw new ArgumentException("Booking skal være i fremtiden");
    }

    protected void AssureNoOverlapping(IEnumerable<Booking> otherBookings)
    {
        if (otherBookings.Any(other =>
                (EndDate <= other.EndDate && EndDate >= other.StartDate) ||
                (StartDate >= other.StartDate && StartDate <= other.EndDate) ||
                (StartDate <= other.StartDate && EndDate >= other.EndDate)))
            throw new Exception("Booking overlapper med en anden booking");
    }

    public bool IsPastBooking()
    {
        return EndDate < DateOnly.FromDateTime(DateTime.Now);
    }

    /// <summary>
    ///     Booking factory method
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <param name="existingBookings"></param>
    /// <returns></returns>
    public static Booking Create(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> existingBookings)
    {
        return new Booking(startDate, endDate, existingBookings);
    }

    public void Update(DateOnly startDate, DateOnly endDate, IEnumerable<Booking> existingBookings)
    {
        StartDate = startDate;
        EndDate = endDate;

        AssureStartDateBeforeEndDate();
        AssureBookingSkalVæreIFremtiden(DateOnly.FromDateTime(DateTime.Now));
        AssureNoOverlapping(existingBookings);
        
        
    }
}