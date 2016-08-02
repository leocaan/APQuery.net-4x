using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryFramework.Relational.Query;
using QueryFramework.Relational.SqlSyntex;
using QueryFramework.Relational.Business.DbDef;

namespace QueryFramework.Tests.Query
{
	[TestClass]
	public class Select_CombineResult_Test
	{

		[TestMethod]
		public virtual void Union_All_Expr()
		{
			var t = CrmDbDef.department;

			var query1 = APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.ParentId == 1);

			var query2 = APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.ParentId == 2);

			var query3 = APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.ParentId == 3);


			// union

			query1
				.union(query2)
				.union(query3)
				.print("... UNION ...");

			// union all
			query1
				.ClearCombineResults()
				.union_all(query2)
				.print("... UNION ALL ...");
		}

		[TestMethod]
		public virtual void Intersect_Minus_Expr()
		{
			var t = CrmDbDef.department;

			var query1 = APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.ParentId == 1);

			var query2 = APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.ParentId == 2);


			// intersect

			query1
				.intersect(query2)
				.print("... INTERSECT ...");

			// minus

			query1
				.ClearCombineResults()
				.except(query2)
				.print("... MINUS ...");
		}


		[TestMethod]
		public virtual void Recursive_Union_Expr()
		{
			var t = CrmDbDef.department;

			var query1 = APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.ParentId == 1);

			var query2 = APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.ParentId == 2);

			var query3 = APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.ParentId == 3);

			query1.union_all(
				query2.union(query3)
				)
				.print("... UNION ALL ( ... UNION ... )");
		}

	}
}
