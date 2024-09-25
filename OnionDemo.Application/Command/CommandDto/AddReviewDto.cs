namespace OnionDemo.Application.Command.CommandDto;

public class AddReviewDto
{
    public int Id { get; set; }
    public int AccommodationId { get; set; }
    public int GuestId { get; set; }
    public string Comment { get; set; } = null!;
    public int Rating { get; set; }
}