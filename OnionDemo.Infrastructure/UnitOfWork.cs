using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnionDemo.Application;
using System.Data;
using System.Transactions;
using IsolationLevel = System.Data.IsolationLevel;

namespace OnionDemo.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _db;

    // IDbContextTransaction is used to manage database transactions in Entity Framework Core.
    // It's a wrapper around the underlying database transaction to provide transaction control.
    private IDbContextTransaction? _dbTransaction;

    public UnitOfWork(DbContext db)
    {
        _db = db;

    }

    // BeginTransaction starts a new database transaction.
    //   isolationLevel: Defines the isolation level to use (default is Serializable to prevent phantom reads/writes).
    //     Highest level of isolation, preventing phantom reads by locking the entire range.
    public void BeginTransactions(IsolationLevel isolationLevel)
    {
        // Ensure there's no existing transaction. Throw an error if one is already active.
        if (_db.Database.CurrentTransaction  != null)
            throw new InvalidOperationException("A transaction has already been started.");

        // Begin the transaction with the specified isolation level.
        // The isolation level controls the level of access other transactions have to the data during this transaction.
        _dbTransaction = _db.Database.BeginTransaction(isolationLevel);
    }

    // Commit finalizes the transaction, making all changes made during the transaction permanent.
    void IUnitOfWork.Commit()
    {
        // If there's no active transaction, throw an error. Commit cannot be called without an open transaction.
        if (_dbTransaction == null)
            throw new InvalidOperationException("No active transaction to commit.");

        // Commit the transaction, saving changes permanently to the database.
        _dbTransaction.Commit();
// Dispose of the transaction object to release resources.
        _dbTransaction.Dispose();

        _dbTransaction = null;
        // Reset transaction after rollback.
        // If working with threads, or
        // possible new transactions will think a transaction is already active.
        //Will result in InvalidOperationException: A transaction has already been started.
    }

    // Rollback cancels the transaction, undoing any changes made during the transaction.
    void IUnitOfWork.Rollback()
    {
        // If there's no active transaction, throw an error. Rollback cannot be called without an open transaction.
        if (_dbTransaction == null)
            throw new InvalidOperationException("No active transaction to rollback.");

        // Rollback the transaction, undoing any database changes made since the transaction began.
        _dbTransaction.Rollback();

        // Dispose of the transaction object to release resources.
        _dbTransaction.Dispose();

        _dbTransaction = null;
        // Reset transaction after rollback.
        // If working with threads, or
        // possible new transactions will think a transaction is already active.
        //Will result in InvalidOperationException: A transaction has already been started.

    }

}