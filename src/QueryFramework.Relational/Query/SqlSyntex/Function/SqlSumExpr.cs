// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlSumExpr : SqlDistinctableFunctionExpr
   {

      #region [ Constructors ]


      public SqlSumExpr(SqlOperableExpr operand)
         : base("SUM")
      {
         Check.NotNull(operand, nameof(operand));


         AddParameter(operand);
      }


      #endregion

   }

}
