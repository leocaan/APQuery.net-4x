using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryFramework.Relational.Query;
using QueryFramework.Relational.SqlSyntex;
using QueryFramework.Relational.Business.DbDef;

namespace QueryFramework.Tests.Query
{
	[TestClass]
	public class Select_OrderByClause_Test
	{

		[TestMethod]
		public virtual void Ordering_Expr()
		{
			var t = CrmDbDef.department;

			APQuery
				.select(t.DepartmentId, t.ParentId, t.DepartmentName, t.CreateDate, t.CancelDate, t.State)
				.from(t)
				.order_by(t.State.Asc, t.DepartmentName.Desc)
				.print("ORDER BY table_source.column_name");
		}

		[TestMethod]
		public virtual void Ordering_Expr_Alias_Expr()
		{
			var t = CrmDbDef.department;

			APQuery
				.select(t.DepartmentId.As("id"), t.DepartmentName.As("name"))
				.from(t)
				.order_by(t.DepartmentId.As("id").Asc, t.DepartmentName.As("name").Desc)
				.print("ORDER BY column.alias");
		}


	}
}
