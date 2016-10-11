// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlInSubQueryExpr : SqlPredicateExpr
   {

      #region [ Constructors ]


      public SqlInSubQueryExpr(SqlOperableExpr operand, SqlSelectExpr subQuery)
      {
         Check.NotNull(operand, nameof(operand));
         Check.NotNull(subQuery, nameof(subQuery));


         Operand = operand;
         SubQuery = subQuery;
      }


      #endregion


      #region [ Properties ]


      public SqlOperableExpr Operand { get; }


      public SqlSelectExpr SubQuery { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitInSubQuery(this);


      #endregion

   }

}
