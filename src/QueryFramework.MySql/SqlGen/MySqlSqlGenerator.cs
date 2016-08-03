﻿using QueryFramework.Relational.SqlGen;
using QueryFramework.Relational.SqlSyntex;
using QueryFramework.Utilities;

namespace QueryFramework.MySql.SqlGen
{

	public class MySqlSqlGenerator : DefaultSqlGenerator
	{

		#region [ Override Implementation of DefaultSqlGenerator ]


		public override string ParameterPrefix => "?";


		public override SqlExpr VisitGroupingSets(SqlMultipleGroupingSetsExprBase groupingSetsExpr)
		{
			throw new System.NotSupportedException(Strings.SqlSyntex_NotSupported_MultipleGroupingSets_Expr("MySql"));
		}


		public override SqlExpr VisitCombineResult(SqlCombineResultExprBase combineResultExpr)
		{
			if (combineResultExpr is SqlIntersectExpr || combineResultExpr is SqlExceptExpr)
				throw new System.NotSupportedException(Strings.SqlSyntex_NotSupported_CombineResult_Expr_Part("MySql"));

			return base.VisitCombineResult(combineResultExpr);
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
				Sql.AppendLine()
					.Append("LIMIT ")
					.Append(selectExpr.Limit ?? -1);

				if (selectExpr.Offset != null)
				{
					Sql.Append(" OFFSET ")
						.Append(selectExpr.Offset);
				}
			}
		}


		#endregion

	}

}
