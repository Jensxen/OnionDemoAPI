using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Query;
using OnionDemo.Application.Query.QueryDto;

namespace OnionDemo.Infrastructure.Queries;

public class HostQuery : IHostQuery
{
    private readonly BookMyHomeContext _db;

    public HostQuery(BookMyHomeContext db)
    {
        _db = db;
    }

    HostDto IHostQuery.getHost(int id)
    {
        var host = _db.Hosts.AsNoTracking().Single(a => a.Id == id);
        return new HostDto
        {
            Id = host.Id,
            RowVersion = host.RowVersion
        };
    }

    IEnumerable<HostDto> IHostQuery.getHosts()
    {
        var result = _db.Hosts.AsNoTracking().Select(a => new HostDto
        {
            Id = a.Id,
            RowVersion = a.RowVersion
        });
        return result;
    }
}