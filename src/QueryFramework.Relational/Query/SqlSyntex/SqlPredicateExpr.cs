// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace QueryFramework.Query.SqlSyntex
{

   public abstract class SqlPredicateExpr : SqlExpr
   {

      #region [ Override Implementation of Operator ]


      public static SqlAndExpr operator &(SqlPredicateExpr left, SqlPredicateExpr right)
         => SqlExpr.AndAlso(left, right);


      public static SqlOrExpr operator |(SqlPredicateExpr left, SqlPredicateExpr right)
         => SqlExpr.OrElse(left, right);


      public static SqlNotExpr operator !(SqlPredicateExpr expr)
         => SqlExpr.Not(expr);


      #endregion

   }

}
