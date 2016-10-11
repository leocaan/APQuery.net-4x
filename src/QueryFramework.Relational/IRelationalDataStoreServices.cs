// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Storage;

namespace QueryFramework.Relational
{

   public interface IRelationalDataStoreServices : IDataStoreServices
   {

      #region [ Properties ]


      IRelationalConnection RelationalConnection { get; }


      ISqlGenerator SqlGenerator { get; }


      #endregion

   }

}
