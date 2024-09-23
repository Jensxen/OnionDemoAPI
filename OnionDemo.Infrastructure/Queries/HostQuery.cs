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

    HostDto? IHostQuery.getHost(int id)
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

    HostDto? IHostQuery.GetAccommodations(int hostid)
    {
        var host = _db.Hosts
            .Include(a => a.Accommodations)
            .ThenInclude(b => b.Bookings)
            .FirstOrDefault(h => h.Id == hostid);

        if (host == null) return null;
        
        return new HostDto
        {
            Id = host.Id,
            Accommodations = host.Accommodations.Select(a => new AccommodationDto
            {
                Id = a.Id,
                HostId = a.Host.Id,
                Bookings = a.Bookings.Select(b => new BookingDto
                {
                    Id = b.Id,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate,
                    RowVersion = b.RowVersion
                })
            })
        };
    }
}