using System.Data;

namespace OnionDemo.Application;

public interface IUnitOfWork
{
    //IsolationLevel is an enum that specifies the isolation level for a transaction.
    //Set to Serializable to prevent phantom reads/writes.
    //Set in interface to allow for easy changes in the future.
    void BeginTransactions(IsolationLevel isolationLevel = IsolationLevel.Serializable);
    void Rollback();
    void Commit();
}
