// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlBetweenExpr : SqlPredicateExpr
   {

      #region [ Constructors ]


      public SqlBetweenExpr(SqlOperableExpr operand, SqlOperableExpr begin, SqlOperableExpr end)
      {
         Check.NotNull(operand, nameof(operand));
         Check.NotNull(begin, nameof(begin));
         Check.NotNull(end, nameof(end));


         Operand = operand;
         Begin = begin;
         End = end;
      }


      #endregion


      #region [ Properties ]


      public SqlOperableExpr Operand { get; }


      public SqlOperableExpr Begin { get; }


      public SqlOperableExpr End { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitBetween(this);


      #endregion

   }

}
