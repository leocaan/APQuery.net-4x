// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlAvgExpr : SqlDistinctableFunctionExpr
   {

      #region [ Constructors ]


      public SqlAvgExpr(SqlOperableExpr operand)
         : base("AVG")
      {
         Check.NotNull(operand, nameof(operand));


         AddParameter(operand);
      }


      #endregion

   }

}
