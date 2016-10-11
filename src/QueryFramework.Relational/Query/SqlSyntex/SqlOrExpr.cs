// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.Sql;
using QueryFramework.Utilities;

namespace QueryFramework.Query.SqlSyntex
{

   public class SqlOrExpr : SqlPredicateExpr
   {

      #region [ Consturctors ]


      public SqlOrExpr(SqlPredicateExpr left, SqlPredicateExpr right)
      {
         Check.NotNull(left, nameof(left));
         Check.NotNull(right, nameof(right));


         Left = left;
         Right = right;
      }


      #endregion


      #region [ Properties ]


      public SqlPredicateExpr Left { get; }


      public SqlPredicateExpr Right { get; }


      #endregion


      #region [ Methods ]


      public override SqlExpr Accept(ISqlExprVisitor visitor)
         => visitor.VisitOr(this);


      #endregion

   }

}
