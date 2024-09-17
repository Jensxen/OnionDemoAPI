using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.IRepository;

public interface IHostRepository
{
    Host GetHost(int hostId);
    void AddHost(Host host);
    void UpdateHost(Host host, byte[] rowVersion);
    void DeleteHost(Host host, byte[] rowVersion);
}