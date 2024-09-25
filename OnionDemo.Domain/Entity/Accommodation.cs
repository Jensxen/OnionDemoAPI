using OnionDemo.Domain.DomainServices;

namespace OnionDemo.Domain.Entity;

public class Accommodation: DomainEntity
{
    private readonly List<Booking> _bookings = new List<Booking>();

    //public List<Booking> Bookings { get; protected set; } = new List<Booking>();
    public Host Host { get; protected set; }
    public ICollection<Review> Reviews { get; protected set; } = new List<Review>();

    //public int HostId { get; protected set; }
    //public string Name { get; protected set; }
    //public string Description { get; protected set; }
    //public string Address { get; protected set; }
    //public string City { get; protected set; }
    //public string Country { get; protected set; }
    //public int Rooms { get; protected set; }
    //public int Beds { get; protected set; }
    //public int Bathrooms { get; protected set; }
    //public int MaxGuests { get; protected set; }
    //public double PricePerNight { get; protected set; }
    //public bool IsActive { get; protected set; }
    //public List<Picture> Pictures { get; protected set; }
    //public List<Review> Reviews { get; protected set; }
    //public List<Amenity> Amenities { get; protected set; }
    //public List<Rules> Rules { get; protected set; }
    //public List<Types> Types { get; protected set; }
    //public List<Service> Services { get; protected set; }
    //public List<Tag> Tags { get; protected set; }

    protected Accommodation()
    {
    }

    protected Accommodation(Host host)
    {
        Host = host;
    }
    //assure no booking before deleting accommodation

    protected void AssureNoBookings()
    {
        if (_bookings.Any())
            throw new Exception("Accommodation has bookings, cannot delete");
    }

    public void Delete()
    {
        AssureNoBookings();
    }

    public IEnumerable<Booking> GetBookings()
    {
        return _bookings.AsEnumerable();
    }

    public IReadOnlyCollection<Booking> Bookings => _bookings;

    public static Accommodation Create(Host host)
    {
        return new Accommodation(host);
    }

    public void Update()
    {
        
    }

    public void UpdateBooking(DateOnly startDate, DateOnly endDate, int bookingId)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == bookingId);
        if (booking == null)
            throw new ArgumentException("Booking not found");
        booking.Update(startDate, endDate, GetBookings());
    }

    public void CreateBooking(DateOnly startDate, DateOnly endDate)
    {
        var booking = Booking.Create(startDate, endDate, GetBookings());
        _bookings.Add(booking);
    }

    public void DeleteBooking(int bookingId)
    {
        var booking = _bookings.FirstOrDefault(b => b.Id == bookingId);
        if (booking == null)
            throw new ArgumentException("Booking not found");
        _bookings.Remove(booking);
    }

    //public void Update(Host host, 
    //    string name, 
    //    string description, 
    //    string address, 
    //    string city, 
    //    string country, 
    //    int rooms, 
    //    int beds, 
    //    int bathrooms, 
    //    int maxGuests, 
    //    double pricePerNight, 
    //    bool isActive)
    //{
    //    Host = host;
    //    Name = name;
    //    Description = description;
    //    Address = address;
    //    City = city;
    //    Country = country;
    //    Rooms = rooms;
    //    Beds = beds;
    //    Bathrooms = bathrooms;
    //    MaxGuests = maxGuests;
    //    PricePerNight = pricePerNight;
    //    IsActive = isActive;
    //}

    
    //public static Accommodation Create(Host host, 
    //    string name, 
    //    string description, 
    //    string address, 
    //    string city, 
    //    string country, 
    //    int rooms, 
    //    int beds, 
    //    int bathrooms, 
    //    int maxGuests, 
    //    double pricePerNight, 
    //    bool isActive
    //    )
    //{
    //    return new Accommodation(host, 
    //        name, 
    //        description, 
    //        address, 
    //        city, 
    //        country, 
    //        rooms, 
    //        beds, 
    //        bathrooms, 
    //        maxGuests, 
    //        pricePerNight, 
    //        isActive);
    //}

}