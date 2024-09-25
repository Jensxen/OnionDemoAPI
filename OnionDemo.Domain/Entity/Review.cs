namespace OnionDemo.Domain.Entity;

public class Review : DomainEntity
{
    public int ReviewId { get; protected set; }
    public int AccommodationId { get; protected set; }
    public int GuestId { get; protected set; }
    public string Comment { get; protected set; }
    public int Rating { get; protected set; }

    public Review(int accommodationId, int guestId, string comment, int rating)
    {
        AccommodationId = accommodationId;
        GuestId = guestId;
        Comment = comment;
        Rating = rating;
    }

    public static Review Create(int accommodationId, int guestId, string comment, int rating)
    {
        return new Review(accommodationId, guestId, comment, rating);
    }
}

