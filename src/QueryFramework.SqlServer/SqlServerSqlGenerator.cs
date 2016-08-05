using QueryFramework.Relational.SqlGen;
using QueryFramework.Relational.SqlSyntex;
using System.Linq;

namespace QueryFramework.SqlServer
{

	public class SqlServerSqlGenerator : DefaultSqlGenerator
	{

		#region [ Override Implementation of DefaultSqlGenerator ]


		protected override string DelimitIdentifier(string identifier)
			=> "[" + identifier.Replace("]", "]]") + "]";


		public override SqlExpr VisitSelect(SqlSelectExpr selectExpr)
		{
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
			if (sourceQuery.Limit != null)
				subQuery.Limit = sourceQuery.Limit + sourceQuery.Offset;


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

			query.WhereClause = SqlExpr.RawSql("ROWID") > sourceQuery.Offset;


			return query;
		}


		#endregion

	}

}
