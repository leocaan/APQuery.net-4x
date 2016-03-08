using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symber.Data.Query;
using Symber.Data.SqlSyntex;

namespace Symber.Data.Tests.Query
{
	[TestClass]
	public class Select_Distinct_Limit_And_Offset_Test
	{

		[TestMethod]
		public virtual void Distinct()
		{
			var t = DbDef.department;

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.distinct()
				.print("SELECT DISTINCT ...");
		}

		[TestMethod]
		public virtual void Limit()
		{
			var t = DbDef.department;

			APQuery
				.select(t.ProjectStar)
				.from(t)
				.where(t.ParentId != null)
				.take(10)
				.print("SELECT TOP 10 ...");
		}

		[TestMethod]
		public virtual void Offset()
		{
			var t = DbDef.department;

			APQuery
				.select(t.ProjectStar)
				.from(t)
				.skip(100)
				.print("SELECT ... OFFSET {rownum} ROWS");
		}

		[TestMethod]
		public virtual void Limit_Offset_Has_Order_Expr()
		{
			var t = DbDef.department;

			APQuery
				.select(t.DepartmentId, t.DepartmentName.As("name"), t.ParentId)
				.from(t)
				.order_by(t.DepartmentId.Desc, t.DepartmentName.As("name").Desc)
				.skip(100)
				.take(10)
				.print("SELECT ... ORDER BY ... OFFSET {rownum} ROWS FETCH NEXT {rownum} ROWS ONLY");
		}

		[TestMethod]
		public virtual void Limit_Offset_Not_Order_Expr()
		{
			var t = DbDef.department;

			APQuery
				.select(t.ProjectStar)
				.from(t)
				.skip(100)
				.take(10)
				.print("SELECT ... Order by @@ROWCOUNT OFFSET {rownum} ROWS FETCH NEXT {rownum} ROWS ONLY");
		}

	}
}
