namespace OnionDemo.Application.Command.CommandDto;

public class DeleteAccommodationDto
{
    public int HostId { get; set; }
    public byte[] RowVersion { get; set; } = null!;
}