namespace OnionDemo.Application.Command.CommandDto;

public class DeleteAccommodationDto
{
    public int Id { get; set; }
    public byte[] RowVersion { get; set; } = null!;
}