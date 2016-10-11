// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlOrderingExpr : SqlExpr
   {

      #region [ Constructors ]


      public SqlOrderingExpr(SqlExpr expr, SqlOrderingDirection orderingDirection)
      {
         Operand = expr;
         OrderingDirection = orderingDirection;
      }


      #endregion


      #region [ Properties ]


      public SqlExpr Operand { get; }


      public SqlOrderingDirection OrderingDirection { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitOrdering(this);


      #endregion

   }

}
