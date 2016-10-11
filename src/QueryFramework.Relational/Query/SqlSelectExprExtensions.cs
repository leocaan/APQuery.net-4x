// Copyright (c) APQuery.NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using QueryFramework.Query.SqlSyntex;
using System.Collections.Generic;

namespace QueryFramework.Query
{

   public static class SqlSelectExprExtensions
   {

      #region [ 'FROM' ]


      public static SqlSelectExpr from(this SqlSelectExpr expr, SqlQuerySourceExpr source)
         => expr.AddToFromClause(source);


      public static SqlSelectExpr innerJoin(this SqlSelectExpr expr, SqlQuerySourceExpr source, SqlPredicateExpr predicate)
         => expr.AddToFromClause(SqlExpr.InnerJoin(source, predicate));


      public static SqlSelectExpr leftJoin(this SqlSelectExpr expr, SqlQuerySourceExpr source, SqlPredicateExpr predicate)
         => expr.AddToFromClause(SqlExpr.LeftJoin(source, predicate));


      public static SqlSelectExpr rightJoin(this SqlSelectExpr expr, SqlQuerySourceExpr source, SqlPredicateExpr predicate)
         => expr.AddToFromClause(SqlExpr.RightJoin(source, predicate));


      public static SqlSelectExpr fullJoin(this SqlSelectExpr expr, SqlQuerySourceExpr source, SqlPredicateExpr predicate)
         => expr.AddToFromClause(SqlExpr.FullJoin(source, predicate));


      public static SqlSelectExpr crossJoin(this SqlSelectExpr expr, SqlQuerySourceExpr source)
         => expr.AddToFromClause(SqlExpr.CrossJoin(source));


      public static SqlSelectExpr lateralJoin(this SqlSelectExpr expr, SqlQuerySourceExpr source)
         => expr.AddToFromClause(SqlExpr.LateralJoin(source));


      #endregion


      #region [ 'DISTINCT', 'LIMIT', 'OFFSET' and 'Primary Key Optimizing' ]


      public static SqlSelectExpr distinct(this SqlSelectExpr expr)
      {
         expr.IsDistinct = true;


         return expr;
      }


      public static SqlSelectExpr take(this SqlSelectExpr expr, SqlOperableExpr rows)
      {
         expr.Limit = rows;


         return expr;
      }


      public static SqlSelectExpr skip(this SqlSelectExpr expr, SqlOperableExpr rows)
      {
         expr.Offset = rows;


         return expr;
      }


      public static SqlSelectExpr optimizing(this SqlSelectExpr expr, SqlColumnExpr primaryKey)
      {
         expr.PrimaryKeyOptimizing = primaryKey;


         return expr;
      }


      #endregion


      #region [ 'WHERE' ]


      public static SqlSelectExpr where(this SqlSelectExpr expr, SqlPredicateExpr predicate)
      {
         expr.WhereClause = predicate;


         return expr;
      }


      #endregion


      #region [ 'GROUP BY' ]


      public static SqlSelectExpr group_by(this SqlSelectExpr expr, SqlGroupableExpr grouping)
         => expr.AddToGroupByClause(grouping);


      public static SqlSelectExpr group_by(this SqlSelectExpr expr, IEnumerable<SqlGroupableExpr> groupings)
         => expr.AddToGroupByClause(groupings);


      public static SqlSelectExpr group_by(this SqlSelectExpr expr, params SqlGroupableExpr[] groupings)
         => expr.AddToGroupByClause(groupings);


      #endregion


      #region [ 'HAVING' ]


      public static SqlSelectExpr having(this SqlSelectExpr expr, SqlPredicateExpr predicate)
      {
         expr.HavingClause = predicate;


         return expr;
      }


      #endregion


      #region [ 'ORDER BY' ]


      public static SqlSelectExpr order_by(this SqlSelectExpr expr, SqlOrderingExpr ordering)
         => expr.AddToOrderByClause(ordering);


      public static SqlSelectExpr order_by(this SqlSelectExpr expr, IEnumerable<SqlOrderingExpr> orderings)
         => expr.AddToOrderByClause(orderings);


      public static SqlSelectExpr order_by(this SqlSelectExpr expr, params SqlOrderingExpr[] orderings)
         => expr.AddToOrderByClause(orderings);


      #endregion


      #region [ 'AS' ]


      public static SqlSelectExpr @as(this SqlSelectExpr expr, string alias)
      {
         expr.Alias = alias;


         return expr;
      }


      #endregion


      #region [ 'UNION', 'UNION ALL', 'INTERSECT', 'EXCEPT' ]


      public static SqlSelectExpr union(this SqlSelectExpr expr, SqlSelectExpr nextQuery)
         => expr.AddToCombineResults(SqlExpr.Union(nextQuery));


      public static SqlSelectExpr union_all(this SqlSelectExpr expr, SqlSelectExpr nextQuery)
         => expr.AddToCombineResults(SqlExpr.UnionAll(nextQuery));


      public static SqlSelectExpr intersect(this SqlSelectExpr expr, SqlSelectExpr nextQuery)
         => expr.AddToCombineResults(SqlExpr.Intersect(nextQuery));


      public static SqlSelectExpr except(this SqlSelectExpr expr, SqlSelectExpr nextQuery)
         => expr.AddToCombineResults(SqlExpr.Except(nextQuery));


      #endregion

   }

}
