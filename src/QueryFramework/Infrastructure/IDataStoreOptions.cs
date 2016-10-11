// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace QueryFramework.Infrastructure
{

   public interface IDataStoreOptions
   {

      #region [ Properties ]


      IEnumerable<IDataStoreOptionsExtension> Extensions { get; }


      #endregion


      #region [ Methods ]


      TExtension FindExtension<TExtension>()
         where TExtension : class, IDataStoreOptionsExtension;


      #endregion

   }

}
