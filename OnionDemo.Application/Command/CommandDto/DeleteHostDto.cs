namespace OnionDemo.Application.Command.CommandDto;

public class DeleteHostDto
{
    public int Id { get; set; }
    public byte[] RowVersion { get; set; }
}