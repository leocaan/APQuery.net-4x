// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace QueryFramework.Relational.Storage
{

   public abstract class DataStoreProvider
   {

      #region [ Methods ]


      public abstract RelationalDataStoreServices CreateServices(string connectionString, string providerName);


      #endregion

   }

}
