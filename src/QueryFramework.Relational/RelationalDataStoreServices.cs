// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Infrastructure;
using QueryFramework.Query.Sql;
using QueryFramework.Storage;

namespace QueryFramework.Relational
{

   public abstract class RelationalDataStoreServices : DataStoreServices, IRelationalDataStoreServices
   {

      #region [ Constructors ]


      protected RelationalDataStoreServices(IDataStoreOptions options)
         : base(options)
      {
      }


      #endregion


      #region [ Properties ]


      public abstract ISqlGenerator SqlGenerator { get; }


      public abstract IRelationalConnection RelationalConnection { get; }


      public override IDataStoreConnection Connection
         => RelationalConnection;


      #endregion

   }

}
