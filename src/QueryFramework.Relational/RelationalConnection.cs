// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Infrastructure;
using QueryFramework.Internal;
using QueryFramework.Utilities;
using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace QueryFramework.Relational
{

   public abstract class RelationalConnection : IRelationalConnection
   {

      #region [ Fields ]


      private readonly string _connectionString;
      private readonly LazyRef<DbConnection> _connection;
      private readonly bool _connectionOwned;
      private int _openedCount;
      private int? _commandTimeout;
      private bool _throwOnAmbientTransaction;


      #endregion


      #region [ Constructors ]


      protected RelationalConnection(IDataStoreOptions options)
      {
         Check.NotNull(options, nameof(options));


         var storeConfig = RelationalOptionsExtension.Extract(options);

         _commandTimeout = storeConfig.CommandTimeout;

         if (storeConfig.Connection != null)
         {
            if (!string.IsNullOrWhiteSpace(storeConfig.ConnectionString))
            {
               throw new InvalidOperationException(RelationalStrings.Connection_ConnectionAndConnectionString);
            }

            _connection = new LazyRef<DbConnection>(() => storeConfig.Connection);
            _connectionOwned = false;
            _openedCount = storeConfig.Connection.State == ConnectionState.Open ? 1 : 0;
         }
         else if (!string.IsNullOrWhiteSpace(storeConfig.ConnectionString))
         {
            _connectionString = storeConfig.ConnectionString;
            _connection = new LazyRef<DbConnection>(CreateDbConnection);
            _connectionOwned = true;
         }
         else
         {
            throw new InvalidOperationException(RelationalStrings.Connection_NoConnectionOrConnectionString);
         }

         _throwOnAmbientTransaction = storeConfig.ThrowOnAmbientTransaction ?? true;
      }


      #endregion


      #region [ Properties ]


      public virtual string ConnectionString
         => _connectionString ?? _connection.Value.ConnectionString;


      public virtual DbConnection DbConnection
         => _connection.Value;


      public virtual RelationalTransaction Transaction { get; protected set; }


      public virtual int? CommandTimeout
      {
         get { return _commandTimeout; }
         set
         {
            if (value.HasValue && value < 0)
            {
               throw new ArgumentException(RelationalStrings.Connection_InvalidCommandTimeout);
            }

            _commandTimeout = value;
         }
      }


      public virtual DbTransaction DbTransaction
         => Transaction?.DbTransaction;

      public virtual bool IsMultipleActiveResultSetsEnabled
         => false;


      #endregion


      #region [ Methods ]


      protected abstract DbConnection CreateDbConnection();


      public virtual RelationalTransaction BeginTransaction()
         => BeginTransaction(IsolationLevel.Unspecified);


      public virtual Task<RelationalTransaction> BeginTransactionAsync(
         CancellationToken cancellationToken = default(CancellationToken))
         => BeginTransactionAsync(IsolationLevel.Unspecified, cancellationToken);


      public virtual RelationalTransaction BeginTransaction(IsolationLevel isolationLevel)
      {
         if (Transaction != null)
         {
            throw new InvalidOperationException(RelationalStrings.Relational_TransactionAlreadyStarted);
         }

         Open();


         return BeginTransactionWithNoPreconditions(isolationLevel);
      }


      public virtual async Task<RelationalTransaction> BeginTransactionAsync(
         IsolationLevel isolationLevel,
         CancellationToken cancellationToken = default(CancellationToken))
      {
         if (Transaction != null)
         {
            throw new InvalidOperationException(RelationalStrings.Relational_TransactionAlreadyStarted);
         }

         await OpenAsync(cancellationToken);


         return BeginTransactionWithNoPreconditions(isolationLevel);
      }


      public virtual RelationalTransaction UseTransaction(DbTransaction transaction)
      {
         if (transaction == null)
         {
            if (Transaction != null)
            {
               Transaction = null;

               Close();
            }
         }
         else
         {
            if (Transaction != null)
            {
               throw new InvalidOperationException(RelationalStrings.Relational_TransactionAlreadyStarted);
            }

            Open();

            Transaction = new RelationalTransaction(this, transaction, /*transactionOwned*/ false);
         }


         return Transaction;
      }


      public virtual void Open()
      {
         CheckForAmbientTransactions();

         if (_openedCount == 0)
         {
            _connection.Value.Open();
         }

         _openedCount++;
      }


      public virtual async Task OpenAsync(CancellationToken cancellationToken = default(CancellationToken))
      {
         CheckForAmbientTransactions();

         if (_openedCount == 0)
         {
            await _connection.Value.OpenAsync(cancellationToken);
         }

         _openedCount++;
      }


      public virtual void Close()
      {
         // TODO: Consider how to handle open/closing to make sure that a connection that is passed in
         // as open is never erroneously closed without placing undue burdon on users of the connection.

         if (_openedCount > 0 && --_openedCount == 0)
         {
            _connection.Value.Close();
         }
      }


      #endregion


      #region [ Private Methods ]


      private RelationalTransaction BeginTransactionWithNoPreconditions(IsolationLevel isolationLevel)
      {
         Transaction = new RelationalTransaction(this, DbConnection.BeginTransaction(isolationLevel), /*transactionOwned*/ true);


         return Transaction;
      }


      private void CheckForAmbientTransactions()
      {
         if (_throwOnAmbientTransaction
            && System.Transactions.Transaction.Current != null)
         {
            throw new InvalidOperationException(RelationalStrings.Relational_AmbientTransaction);
         }
      }


      #endregion


      #region [ Implementation of IDisposable ]


      public virtual void Dispose()
      {
         Transaction?.Dispose();

         if (_connectionOwned && _connection.HasValue)
         {
            _connection.Value.Dispose();
            _connection.Reset(CreateDbConnection);
            _openedCount = 0;
         }
      }


      #endregion

   }

}
