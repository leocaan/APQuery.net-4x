using Symber.Data.SqlGen;
using Symber.Data.SqlSyntex;
using Symber.Data.Utilities;
using System.Linq;

namespace Symber.Data.Oracle.Query
{

	public class OracleSqlGenerator : DefaultSqlGenerator
	{

		#region [ Override Implementation of DefaultSqlGenerator ]


		public override SqlExpr VisitCombineResult(SqlCombineResultExprBase combineResultExpr)
		{
			Check.NotNull(combineResultExpr, nameof(combineResultExpr));


			if (!(combineResultExpr is SqlExceptExpr))
			{
				return base.VisitCombineResult(combineResultExpr);
			}

			Sql.AppendLine("MINUS");

			if (combineResultExpr.NextQuery.CombineResults.Any())
			{
				Sql.AppendLine("(");
			}

			Visit(combineResultExpr.NextQuery);

			if (combineResultExpr.NextQuery.CombineResults.Any())
			{
				Sql.AppendLine()
					 .AppendLine(")");
			}


			return combineResultExpr;
		}


		public override SqlExpr VisitSelect(SqlSelectExpr selectExpr)
		{
			if (selectExpr.Limit != null && selectExpr.Offset == null)
			{
				var cloneQuery = CloneQuery(selectExpr);

				base.VisitSelect(cloneQuery);

				return selectExpr;
			}

			if (selectExpr.Offset != null)
			{
				var subQuery = PushDownSubQuery(selectExpr, 0);
				var keepQuery = KeepQuery(selectExpr, subQuery);

				VisitSelect(keepQuery);

				return selectExpr;
			}

			return base.VisitSelect(selectExpr);
		}


		#endregion


		#region [ Private Methods ]


		private SqlSelectExpr CloneQuery(SqlSelectExpr sourceQuery)
		{
			var query = new SqlSelectExpr();


			query.AddToSelectClause(sourceQuery.SelectClause);
			query.AddToFromClause(sourceQuery.FromClause);
			query.AddToGroupByClause(sourceQuery.GroupByClause);
			query.AddToOrderByClause(sourceQuery.OrderByClause);
			query.HavingClause = sourceQuery.HavingClause;

			var limitExpr = SqlExpr.RawSql("ROWNUM") <= sourceQuery.Limit;
			query.WhereClause = sourceQuery.WhereClause != null
				? sourceQuery.WhereClause & limitExpr
				: limitExpr;

			query.IsDistinct = sourceQuery.IsDistinct;


			return query;
		}


		private SqlSelectExpr PushDownSubQuery(SqlSelectExpr sourceQuery, int depth)
		{
			var subQuery = new SqlSelectExpr("t_" + depth);

			subQuery.AddToSelectClause(sourceQuery.SelectClause);

			var overExpr = SqlExpr.Over(SqlExpr.RowNumber());
			if (sourceQuery.OrderByClause.Any())
			{
				foreach (var order in sourceQuery.OrderByClause)
				{
					var aliasExpr = order.Operand as SqlAliasExpr;

					if (aliasExpr != null)
					{
						overExpr.AddToOrderByClause(new SqlOrderingExpr(aliasExpr.Operand, order.OrderingDirection));
					}
					else
					{
						overExpr.AddToOrderByClause(order);
					}
				}
			}
			else
			{
				overExpr.AddToOrderByClause(SqlExpr.RawSql("@@ROWCOUNT").Asc);
			}
			subQuery.AddToSelectClause(overExpr.As("ROWID"));

			subQuery.AddToFromClause(sourceQuery.FromClause);
			subQuery.WhereClause = sourceQuery.WhereClause;
			subQuery.AddToGroupByClause(sourceQuery.GroupByClause);
			subQuery.HavingClause = sourceQuery.HavingClause;

			subQuery.IsDistinct = sourceQuery.IsDistinct;


			return subQuery;
		}


		private SqlSelectExpr KeepQuery(SqlSelectExpr sourceQuery, SqlSelectExpr subQuery)
		{
			var query = new SqlSelectExpr();


			foreach (var expr in sourceQuery.SelectClause)
			{
				if (expr.ResultName != null)
				{
					query.AddToSelectClause(new SqlColumnExpr(subQuery, expr.ResultName));
				}
				else
				{
					query.ClearSelectClause()
						  .AddToSelectClause(SqlExpr.Star);
					break;
				}
			}

			query.AddToFromClause(subQuery);

			if (sourceQuery.Limit == null)
			{
				query.WhereClause = SqlExpr.RawSql("ROWID") > sourceQuery.Offset;
			}
			else
			{
				query.WhereClause = SqlExpr.RawSql("ROWID").Between(sourceQuery.Offset + 1, sourceQuery.Offset + sourceQuery.Limit);
			}


			return query;
		}


		#endregion

	}

}
