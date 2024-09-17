using System.ComponentModel.DataAnnotations;

namespace OnionDemo.Application.Query.QueryDto;

public class HostDto
{
    public int Id { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
}