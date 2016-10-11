// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.SqlSyntex;

namespace QueryFramework.Query
{

   public static class SqlQuerySourceExprExtensions
   {

      #region [ Methods ]


      public static SqlInnerJoinExpr InnerJoin(this SqlQuerySourceExpr source, SqlPredicateExpr predicate)
         => SqlExpr.InnerJoin(source, predicate);


      public static SqlLeftOuterJoinExpr LeftJoin(this SqlQuerySourceExpr source, SqlPredicateExpr predicate)
         => SqlExpr.LeftJoin(source, predicate);


      public static SqlRightOuterJoinExpr RightJoin(this SqlQuerySourceExpr source, SqlPredicateExpr predicate)
         => SqlExpr.RightJoin(source, predicate);


      public static SqlFullOuterJoinExpr FullJoin(this SqlQuerySourceExpr source, SqlPredicateExpr predicate)
         => SqlExpr.FullJoin(source, predicate);


      public static SqlCrossJoinExpr CrossJoin(this SqlQuerySourceExpr source)
         => SqlExpr.CrossJoin(source);


      public static SqlLateralJoinExpr LateralJoin(this SqlQuerySourceExpr source)
         => SqlExpr.LateralJoin(source);


      #endregion

   }

}
