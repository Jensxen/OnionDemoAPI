using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.IRepository;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Infrastructure;

public class HostRepository : IHostRepository
{
    private readonly BookMyHomeContext _db;
    public HostRepository(BookMyHomeContext db)
    {
        _db = db;
    }

    Host IHostRepository.GetHost(int hostId)
    {
        return _db.Hosts.Single(h => h.Id == hostId);
    }

    void IHostRepository.AddHost(Host host)
    {
        _db.Hosts.Add(host);
    }

    void IHostRepository.UpdateHost(Host host, byte[] rowVersion)
    {
        _db.Entry(host).Property(nameof(host.RowVersion)).OriginalValue = rowVersion;
        _db.Hosts.Update(host);
    }

    public void DeleteHost(Host host, byte[] rowVersion)
    {
        _db.Entry(host).Property(nameof(host.RowVersion)).OriginalValue = rowVersion;
        _db.Hosts.Remove(host);
    }
}