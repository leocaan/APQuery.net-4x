// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlCountExpr : SqlDistinctableFunctionExpr
   {

      #region [ Constructors ]


      public SqlCountExpr(SqlOperableExpr operand)
         : base("COUNT")
      {
         Check.NotNull(operand, nameof(operand));


         AddParameter(operand);
      }


      public SqlCountExpr()
         : base("COUNT")
      {
      }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitCount(this);


      #endregion

   }

}
