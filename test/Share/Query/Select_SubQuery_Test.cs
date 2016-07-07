using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symber.Data.Query;
using Symber.Data.SqlSyntex;
using Symber.Data.Tests.Business.DbDef;

namespace Symber.Data.Tests.Query
{
	[TestClass]
	public class Select_SubQuery_Test
	{

		[TestMethod]
		public virtual void Exists_Expr()
		{
			var t = DbDef.department;
			var e = DbDef.employee;

			// Sub query

			var subQuery = APQuery
				.select(t.ProjectStar)
				.from(t)
				.where(t.DepartmentId == e.DepartmentId & e.Lastname == "Johnson");

			// Exist

			APQuery
				.select(e.EmployeeId, e.Firstname, e.Lastname)
				.from(e)
				.where(SqlExpr.Exists(subQuery))
				.print("WHERE EXIST (subquery)");

			// Exist

			APQuery
				.select(e.EmployeeId, e.Firstname, e.Lastname)
				.from(e)
				.where(SqlExpr.NotExists(subQuery))
				.print("WHERE NOT EXIST (subquery)");

		}

		[TestMethod]
		public virtual void InSubQuery_Expr()
		{
			var t = DbDef.department;
			var e = DbDef.employee;

			// Sub query

			var subQuery = APQuery
				.select(e.Lastname)
				.from(t)
				.where(t.DepartmentId == e.DepartmentId & e.Lastname == "Johnson");

			// Exist

			APQuery
				.select(e.EmployeeId, e.Firstname, e.Lastname)
				.from(e)
				.where(SqlExpr.In(e.Lastname, subQuery))
				.print("WHERE column_name IN (subquery)");

			// Exist

			APQuery
				.select(e.EmployeeId, e.Firstname, e.Lastname)
				.from(e)
				.where(e.Lastname.NotIn(subQuery))
				.print("WHERE column_name NOT IN (subquery)");

		}

		[TestMethod]
		public virtual void ComparisonSubQuery_Expr()
		{
			var t = DbDef.department;
			var e = DbDef.employee;

			// Sub query

			var subQuery = APQuery
				.select(e.Lastname)
				.from(t)
				.where(t.DepartmentId == e.DepartmentId & e.Lastname == "Johnson");

			// ANY

			APQuery
				.select(e.EmployeeId, e.Firstname, e.Lastname)
				.from(e)
				.where(t.DepartmentId == SqlExpr.Any(subQuery))
				.print("WHERE column_name = ANY (subquery)");

			// ALL

			APQuery
				.select(e.EmployeeId, e.Firstname, e.Lastname)
				.from(e)
				.where(t.DepartmentId >= SqlExpr.All(subQuery))
				.print("WHERE column_name >= ALL (subquery)");

			// None

			APQuery
				.select(e.EmployeeId, e.Firstname, e.Lastname)
				.from(e)
				.where(t.DepartmentName == subQuery)
				.print("WHERE column_name == (subquery)");

		}

	}
}
