// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace QueryFramework.Storage
{

   public interface IRelationalParameterBuilder
   {

      #region [ Properties ]


      IReadOnlyList<IRelationalParameter> Parameters { get; }


      #endregion


      #region [ Methods ]


      void AddParameter(string invariantName, string name, object value);


      #endregion

   }

}
