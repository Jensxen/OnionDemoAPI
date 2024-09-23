namespace OnionDemo.Application.Command.CommandDto;

public class DeleteBookingDto
{
    public int Id { get; set; }
    public int AccommodationId { get; set; }
    public byte[] RowVersion { get; set; } = null!;
}