// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace QueryFramework.Infrastructure
{

   public interface IDataStoreOptionsBuilderExtender
   {

      #region [ Methods ]


      void AddOrUpdateExtension<TExtension>(TExtension extension)
         where TExtension : class, IDataStoreOptionsExtension;


      #endregion

   }

}
