using Symber.Data.SqlGen;
using Symber.Data.SqlSyntex;
using Symber.Data.Utilities;
using System.Linq;

namespace Symber.Data.Oracle12.Query
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


		protected override void GenerateTop(SqlSelectExpr selectExpr)
		{
			// Handled by GenerateLimitOffset
		}


		protected override void GenerateLimitOffset(SqlSelectExpr selectExpr)
		{
			Check.NotNull(selectExpr, nameof(selectExpr));


			if (selectExpr.Limit != null || selectExpr.Offset != null)
			{
				if (!selectExpr.OrderByClause.Any()) {
					Sql.AppendLine()
						.Append("ORDER BY @@ROWCOUNT");
				}

				if (selectExpr.Offset != null)
				{
					Sql.AppendLine()
						.Append("OFFSET ")
						.Append(selectExpr.Offset)
						.Append(" ROWS");

					if (selectExpr.Limit != null)
					{
						Sql.Append(" FETCH NEXT ")
							.Append(selectExpr.Limit)
							.Append(" ROWS ONLY");
					}
				}
				else if (selectExpr.Limit != null)
				{
					Sql.Append(" FETCH FIRST ")
						.Append(selectExpr.Limit)
						.Append(" ROWS ONLY");
				}
			}
		}


		#endregion

	}

}
