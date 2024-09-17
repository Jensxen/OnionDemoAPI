namespace OnionDemo.Application.Command.CommandDto;

public class UpdateHostDto
{
    public int Id { get; set; }
    public byte[] RowVersion { get; set; }
}