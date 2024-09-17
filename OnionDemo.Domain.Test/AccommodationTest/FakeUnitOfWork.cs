using System.Data;
using OnionDemo.Application.IRepository;
using System.Threading.Tasks;
using OnionDemo.Application;

namespace OnionDemo.Domain.Test.BookingTests.Fakes
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public Task<int> CommitAsync()
        {
            return Task.FromResult(1);
        }

        // Add other methods as needed
        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable)
        {
            throw new NotImplementedException();
        }
    }
}