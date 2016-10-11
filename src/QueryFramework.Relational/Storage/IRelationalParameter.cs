// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Data.Common;

namespace QueryFramework.Storage
{

   public interface IRelationalParameter
   {

      #region [ Properties ]


      string InvariantName { get; }


      string Name { get; }


      object Value { get; }


      #endregion


      #region [ Methods ]


      void AddDbParameter(DbCommand command);


      #endregion

   }

}
