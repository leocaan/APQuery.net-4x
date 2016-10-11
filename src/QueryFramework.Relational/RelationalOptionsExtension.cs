// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Infrastructure;
using QueryFramework.Internal;
using QueryFramework.Utilities;
using System;
using System.Data.Common;
using System.Linq;

namespace QueryFramework.Relational
{

   public abstract class RelationalOptionsExtension : IDataStoreOptionsExtension
   {

      #region [ Static Methods ]


      public static RelationalOptionsExtension Extract(IDataStoreOptions options)
      {
         Check.NotNull(options, nameof(options));


         var storeConfigs = options.Extensions
             .OfType<RelationalOptionsExtension>()
             .ToArray();

         if (storeConfigs.Length == 0)
         {
            throw new InvalidOperationException(RelationalStrings.Connection_NoDataStoreConfigured);
         }

         if (storeConfigs.Length > 1)
         {
            throw new InvalidOperationException(RelationalStrings.Connection_MultipleDataStoresConfigured);
         }


         return storeConfigs[0];
      }


      #endregion


      #region [ Fields ]


      private string _connectionString;
      private DbConnection _connection;
      private int? _commandTimeout;
      private int? _maxBatchSize;


      #endregion


      #region [ Constructors ]


      protected RelationalOptionsExtension()
      {
      }


      protected RelationalOptionsExtension(RelationalOptionsExtension copyFrom)
      {
         Check.NotNull(copyFrom, nameof(copyFrom));


         _connectionString = copyFrom._connectionString;
         _connection = copyFrom._connection;
         _commandTimeout = copyFrom._commandTimeout;
         _maxBatchSize = copyFrom._maxBatchSize;
      }


      #endregion


      #region [ Properties ]


      public virtual string ConnectionString
      {
         get { return _connectionString; }

         set
         {
            Check.NotEmpty(value, nameof(value));

            _connectionString = value;
         }
      }


      public virtual DbConnection Connection
      {
         get { return _connection; }

         set
         {
            Check.NotNull(value, nameof(value));

            _connection = value;
         }
      }

      public virtual int? CommandTimeout
      {
         get { return _commandTimeout; }

         set
         {
            if (value.HasValue && value <= 0)
            {
               throw new InvalidOperationException(RelationalStrings.Connection_InvalidCommandTimeout);
            }

            _commandTimeout = value;
         }
      }


      public virtual int? MaxBatchSize
      {
         get { return _maxBatchSize; }

         set
         {
            if (value.HasValue && value <= 0)
            {
               throw new InvalidOperationException(RelationalStrings.Connection_InvalidMaxBatchSize);
            }

            _maxBatchSize = value;
         }
      }


      public virtual bool? ThrowOnAmbientTransaction { get; set; }


      #endregion

   }

}
