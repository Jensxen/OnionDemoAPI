﻿namespace OnionDemo.Domain.Entity;

public class Accommodation: DomainEntity
{
    public Host Host { get; protected set; }

    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public string Address { get; protected set; }
    public string City { get; protected set; }
    public string Country { get; protected set; }
    public int Rooms { get; protected set; }
    public int Beds { get; protected set; }
    public int Bathrooms { get; protected set; }
    public int MaxGuests { get; protected set; }
    public double PricePerNight { get; protected set; }
    public bool IsActive { get; protected set; }
    public List<Booking> Bookings { get; protected set; }
    //public List<Picture> Pictures { get; protected set; }
    //public List<Review> Reviews { get; protected set; }
    //public List<Amenity> Amenities { get; protected set; }
    //public List<Rules> Rules { get; protected set; }
    //public List<Types> Types { get; protected set; }
    //public List<Service> Services { get; protected set; }
    //public List<Tag> Tags { get; protected set; }

    public Accommodation()
    {
    }

    public Accommodation(Host host, string name, string description, string address, string city, string country, int rooms, int beds, int bathrooms, int maxGuests, double pricePerNight, bool isActive)
    {
        Host = host;
        Name = name;
        Description = description;
        Address = address;
        City = city;
        Country = country;
        Rooms = rooms;
        Beds = beds;
        Bathrooms = bathrooms;
        MaxGuests = maxGuests;
        PricePerNight = pricePerNight;
        IsActive = isActive;
    }



}