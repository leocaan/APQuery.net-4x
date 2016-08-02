using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryFramework.Relational.Query;
using QueryFramework.Relational.SqlSyntex;
using QueryFramework.Relational.Business.DbDef;

namespace QueryFramework.Tests.Query
{
	[TestClass]
	public class Select_Function_Test
	{

		[TestMethod]
		public virtual void RankingWindow_Func()
		{
			var t = CrmDbDef.department;



			// ROW_NUMBER OVER
			{
				var overExpr = SqlExpr.Over(SqlExpr.RowNumber())
					.AddToPartitionByClause(t.ParentId)
					.AddToOrderByClause(t.DepartmentId.Desc);

				APQuery
					.select(t.DepartmentId, t.DepartmentName, overExpr.As("Row Number"))
					.from(t)
					.print("SELECT ROW_NUMBER() OVER( [ PARTITION BY value_expression , ... [ n ] ] < ORDER BY_Clause >)");
			}

			// RANK OVER
			{
				var overExpr = SqlExpr.Over(SqlExpr.Rank())
					.AddToPartitionByClause(t.ParentId)
					.AddToOrderByClause(t.DepartmentId.Desc);

				APQuery
					.select(t.DepartmentId, t.DepartmentName, overExpr.As("Rank"))
					.from(t)
					.print("SELECT RANK() OVER( [ PARTITION BY value_expression , ... [ n ] ] < ORDER BY_Clause >)");
			}

			// DENSE_RANK OVER
			{
				var overExpr = SqlExpr.Over(SqlExpr.DenseRank())
					.AddToPartitionByClause(t.ParentId)
					.AddToOrderByClause(t.DepartmentId.Desc);

				APQuery
						.select(t.DepartmentId, t.DepartmentName, overExpr.As("Rank"))
					.from(t)
					.print("SELECT DENSERANK() OVER( [ PARTITION BY value_expression , ... [ n ] ] < ORDER BY_Clause >)");
			}

			// NTILE OVER
			{
				var overExpr = SqlExpr.Over(SqlExpr.Ntile(5))
					.AddToPartitionByClause(t.ParentId)
					.AddToOrderByClause(t.DepartmentId.Desc);

				APQuery
					.select(t.DepartmentId, t.DepartmentName, overExpr.As("Rank"))
					.from(t)
					.print("SELECT NTILE(number) OVER( [ PARTITION BY value_expression , ... [ n ] ] < ORDER BY_Clause >)");
			}
		}


		[TestMethod]
		public virtual void Aggregate_Expr()
		{
			var t = CrmDbDef.department;

			// avg

			APQuery
				.select(t.DepartmentId, SqlExpr.Avg(t.DepartmentId).As("avg"))
				.from(t)
				.group_by(t.DepartmentId)
				.print("SELECT AVG(column_name)");

			// sum

			APQuery
				.select(t.DepartmentId, t.DepartmentId.Sum().Distinct().As("sum"))
				.from(t)
				.group_by(t.DepartmentId)
				.print("SELECT SUM(column_name)");

			// max

			APQuery
				.select(t.DepartmentId, t.DepartmentId.Max().As("max"))
				.from(t)
				.group_by(t.DepartmentId)
				.print("SELECT MAX(column_name)");

			// min

			APQuery
				.select(t.DepartmentId, t.DepartmentId.Min().As("min"))
				.from(t)
				.group_by(t.DepartmentId)
				.print("SELECT MIN(column_name)");

			// count

			APQuery
				.select(t.DepartmentId, t.DepartmentId.Count().As("count"))
				.from(t)
				.group_by(t.DepartmentId)
				.print("SELECT COUNT(column_name)");

			// count *

			APQuery
				.select(t.DepartmentId, SqlExpr.CountStar)
				.from(t)
				.group_by(t.DepartmentId)
				.print("SELECT COUNT(*)");
		}


		[TestMethod]
		public virtual void Aggregate_Over_Expr()
		{
			var t = CrmDbDef.department;


			// avg
			{
				var overExpr = SqlExpr.Over(SqlExpr.Avg(t.DepartmentId))
					.AddToPartitionByClause(t.ParentId);

				APQuery
					.select(t.DepartmentId, overExpr.As("avg"))
					.from(t)
					.group_by(t.DepartmentId)
					.print("SELECT AVG(column_name) OVER(...)");
			}

			// sum
			{
				var overExpr = SqlExpr.Over(SqlExpr.Sum(t.DepartmentId))
					.AddToPartitionByClause(t.ParentId);

				APQuery
					.select(t.DepartmentId, overExpr.As("sum"))
					.from(t)
					.group_by(t.DepartmentId)
					.print("SELECT SUM(column_name) OVER(...)");
			}

			// max
			{
				var overExpr = SqlExpr.Over(SqlExpr.Max(t.DepartmentId))
					.AddToPartitionByClause(t.ParentId);

				APQuery
					.select(t.DepartmentId, overExpr.As("max"))
					.from(t)
					.group_by(t.DepartmentId)
					.print("SELECT MAX(column_name) OVER(...)");
			}

			// min
			{
				var overExpr = SqlExpr.Over(SqlExpr.Min(t.DepartmentId))
					.AddToPartitionByClause(t.ParentId);

				APQuery
					.select(t.DepartmentId, overExpr.As("min"))
					.from(t)
					.group_by(t.DepartmentId)
					.print("SELECT MIN(column_name) OVER(...)");
			}

			// min
			{
				var overExpr = SqlExpr.Over(SqlExpr.Count(t.DepartmentId))
					.AddToPartitionByClause(t.ParentId);

				APQuery
					.select(t.DepartmentId, overExpr.As("count"))
					.from(t)
					.group_by(t.DepartmentId)
					.print("SELECT COUNT(column_name) OVER(...)");
			}
		}


		[TestMethod]
		public virtual void DistinctableFunction_Expr()
		{
			var t = CrmDbDef.department;

			APQuery
				.select(t.DepartmentId, SqlExpr.DistFunc("STDEV", t.DepartmentId).Distinct().As("stdev"))
				.from(t)
				.group_by(t.DepartmentId)
				.print("SqlServer - STDEV(column_name)");

			{
				var overExpr = SqlExpr.Over(SqlExpr.DistFunc("STDEV", t.DepartmentId))
					 .AddToPartitionByClause(t.ParentId);

				APQuery
					.select(t.DepartmentId, overExpr.As("stdev"))
					.from(t)
					.group_by(t.DepartmentId)
					.print("SqlServer - STDEV(column_name) OVER(...)");
			}

			APQuery
				.select(t.DepartmentId, SqlExpr.DistFunc("VARIANCE", t.DepartmentId).Distinct().As("var"))
				.from(t)
				.group_by(t.DepartmentId)
				.print("Oracle - VARIANCE(column_name)");
		}

	}
}
