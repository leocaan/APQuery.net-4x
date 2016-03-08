using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symber.Data.Query;
using Symber.Data.SqlSyntex;

namespace Symber.Data.Tests.Query
{
	[TestClass]
	public class Select_GroupByClause_Test
	{

		[TestMethod]
		public virtual void Groupable_Expr()
		{
			var t = DbDef.department;

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.group_by(t.DepartmentId, t.DepartmentName)
				.print("GROUP BY table_source.column_name");
		}

		[TestMethod]
		public virtual void Groupable_Expr_having()
		{
			var t = DbDef.department;

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.group_by(t.DepartmentId, t.DepartmentName)
				.having(t.DepartmentId == 0)
				.print("GROUP BY table_source.column_name HAVING table_source.column_name = @param");
		}

		[TestMethod]
		public virtual void Grouping_Func()
		{
			var t = DbDef.department;


			// Rollup

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.group_by(t.ParentId, SqlExpr.Rollup(t.DepartmentId, t.DepartmentName))
				.print("GROUP BY table_source.column_name, ROLLUP (...)");

			// Cube

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.group_by(t.ParentId, SqlExpr.Cube(t.DepartmentId, t.DepartmentName))
				.print("GROUP BY table_source.column_name, CUBE (...)");

			// Grouping sets

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.group_by(t.ParentId, SqlExpr.GroupingSets(t.DepartmentId, t.DepartmentName))
				.print("GROUP BY table_source.column_name, GROUPING SETS (...)");

		}

	}
}
