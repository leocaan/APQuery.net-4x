// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Internal;
using QueryFramework.Storage;
using QueryFramework.Utilities;
using System;
using System.Data.Common;
using System.Diagnostics;

namespace QueryFramework.Relational
{

   public class RelationalTransaction : DataStoreTransaction
   {

      #region [ Fields ]


      private readonly bool _transactionOwned;
      private bool _disposed;


      #endregion


      #region [ Constructors ]


      public RelationalTransaction(
         IRelationalConnection connection,
         DbTransaction dbTransaction,
         bool transactionOwned)
      {
         Check.NotNull(connection, nameof(connection));
         Check.NotNull(dbTransaction, nameof(dbTransaction));


         if (connection.DbConnection != dbTransaction.Connection)
         {
            throw new InvalidOperationException(RelationalStrings.Relational_TransactionAssociatedWithDifferentConnection);
         }

         Connection = connection;
         DbTransaction = dbTransaction;
         _transactionOwned = transactionOwned;
      }


      #endregion

      
      #region [ Properties ]


      public virtual DbTransaction DbTransaction { get; }


      public virtual IRelationalConnection Connection { get; }
      

      #endregion


      #region [ Methods ]


      public override void Commit()
      {
         DbTransaction.Commit();
         ClearTransaction();
      }


      public override void Rollback()
      {
         DbTransaction.Rollback();
         ClearTransaction();
      }


      public override void Dispose()
      {
         if (!_disposed)
         {
            _disposed = true;
            if (_transactionOwned)
            {
               DbTransaction.Dispose();
            }
            ClearTransaction();
         }
      }


      #endregion


      #region [ Private Methods ]


      private void ClearTransaction()
      {
         Debug.Assert(Connection.Transaction == null || Connection.Transaction == this);

         Connection.UseTransaction(null);
      }


      #endregion

   }

}
