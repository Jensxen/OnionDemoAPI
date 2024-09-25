using System.ComponentModel.DataAnnotations;

namespace OnionDemo.Application.Query.QueryDto;

public class ReviewDto
{
    public int Id { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
    public int AccommodationId { get; set; }
    public int GuestId { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}