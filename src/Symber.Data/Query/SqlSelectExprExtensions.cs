using Symber.Data.SqlSyntex;
using System.Collections.Generic;

namespace Symber.Data.Query
{

	public static class SqlSelectExprExtensions
	{

		#region [ 'FROM' ]


		public static SqlSelectExpr from(this SqlSelectExpr expr, SqlQuerySourceExpr source)
			=> expr.AddToFromClause(source);


		public static SqlSelectExpr from(this SqlSelectExpr expr, IEnumerable<SqlQuerySourceExpr> sources)
			=> expr.AddToFromClause(sources);


		public static SqlSelectExpr from(this SqlSelectExpr expr, params SqlQuerySourceExpr[] sources)
			=> expr.AddToFromClause(sources);


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


		#endregion


		#region [ 'DISTINCT', 'LIMIT', 'OFFSET' and 'Primary Key Optimizing' ]


		public static SqlSelectExpr distinct(this SqlSelectExpr expr)
		{
			expr.IsDistinct = true;

			return expr;
		}


		public static SqlSelectExpr take(this SqlSelectExpr expr, int rows)
		{
			expr.Limit = rows == 0 ? null : (int?)rows;

			return expr;
		}


		public static SqlSelectExpr skip(this SqlSelectExpr expr, int rows)
		{
			expr.Offset = rows == 0 ? null : (int?)rows;

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
