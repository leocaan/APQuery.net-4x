// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Storage;
using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace QueryFramework.Relational
{

   public interface IRelationalConnection : IDataStoreConnection, IDisposable
   {

      #region [ Properties ]


      string ConnectionString { get; }


      DbConnection DbConnection { get; }


      RelationalTransaction Transaction { get; }


      int? CommandTimeout { get; set; }


      bool IsMultipleActiveResultSetsEnabled { get; }


      #endregion


      #region [ Methods ]


      RelationalTransaction BeginTransaction();


      Task<RelationalTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default(CancellationToken));


      RelationalTransaction BeginTransaction(IsolationLevel isolationLevel);


      Task<RelationalTransaction> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default(CancellationToken));


      RelationalTransaction UseTransaction(DbTransaction transaction);


      void Open();


      Task OpenAsync(CancellationToken cancellationToken = default(CancellationToken));


      void Close();


      #endregion

   }

}
