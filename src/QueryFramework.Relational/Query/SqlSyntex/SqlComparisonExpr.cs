// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlComparisonExpr : SqlPredicateExpr
   {

      #region [ Constructors ]


      public SqlComparisonExpr(SqlOperableExpr left, SqlExpr right, SqlComparisonOperator @operator)
      {
         Check.NotNull(left, nameof(left));
         Check.NotNull(right, nameof(right));


         Left = left;
         Right = right;
         Operator = @operator;
      }


      #endregion


      #region [ Properties ]


      public SqlOperableExpr Left { get; }


      public SqlExpr Right { get; }


      public SqlComparisonOperator Operator { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitComparison(this);


      #endregion

   }

}
