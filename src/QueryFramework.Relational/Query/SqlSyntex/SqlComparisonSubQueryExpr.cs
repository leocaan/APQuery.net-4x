// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlComparisonSubQueryExpr : SqlPredicateExpr
   {

      #region [ Constructors ]


      public SqlComparisonSubQueryExpr(SqlOperableExpr operand, SqlScalarSubQueryExpr subQuery, SqlComparisonOperator @operator)
      {
         Check.NotNull(operand, nameof(operand));
         Check.NotNull(subQuery, nameof(subQuery));


         Operand = operand;
         SubQuery = subQuery;
         Operator = @operator;
      }


      #endregion


      #region [ Properties ]


      public SqlOperableExpr Operand { get; }


      public SqlScalarSubQueryExpr SubQuery { get; }


      public SqlComparisonOperator Operator { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitComparisonSubQuery(this);


      #endregion

   }

}
