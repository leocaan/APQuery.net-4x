// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Infrastructure;
using QueryFramework.Internal;

namespace QueryFramework.Storage
{

   public interface IRelationalCommandBuilder : IInfrastructure<IndentedStringBuilder>
   {

      #region [ Properties ]


      IRelationalParameterBuilder ParameterBuilder { get; }


      #endregion


      #region [ Methods ]


      IRelationalCommand Build();


      #endregion

   }

}
