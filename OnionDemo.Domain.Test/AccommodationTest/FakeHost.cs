using OnionDemo.Application.IRepository;
using OnionDemo.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OnionDemo.Domain.Test.BookingTests.Fakes
{
    public class FakeHostRepository : IHostRepository
    {
        private readonly List<Host> _hosts = new List<Host>();

        public Host GetHost(int id)
        {
            return _hosts.SingleOrDefault(h => h.Id == id);
        }

        public void AddHost(Host host)
        {
            _hosts.Add(host);
        }

        public void UpdateHost(Host host, byte[] rowVersion)
        {
            throw new NotImplementedException();
        }

        public void DeleteHost(Host host, byte[] rowVersion)
        {
            throw new NotImplementedException();
        }

        // Add other methods as needed
    }
}