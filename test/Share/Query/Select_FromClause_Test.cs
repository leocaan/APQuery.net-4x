using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symber.Data.Query;
using Symber.Data.SqlSyntex;
using Symber.Data.Tests.Business.DbDef;

namespace Symber.Data.Tests.Query
{
	[TestClass]
	public class Select_FromClause_Test
	{

		[TestMethod]
		public virtual void Table_Expr()
		{
			var t = DbDef.department;

			APQuery
				.select(t.DepartmentId, t.ParentId, t.DepartmentName, t.CreateDate, t.CancelDate, t.State)
				.from(t)
				.print("FROM table_name AS table_alias");
		}


		[TestMethod]
		public virtual void Table_Expr_Alias()
		{
			var t = DbDef.department.As<DepartmentTableDef>("t2");

			APQuery
				.select(t.DepartmentId, t.ParentId, t.DepartmentName, t.CreateDate, t.CancelDate, t.State)
					.from(t)
					.print("FROM table_name AS table_alias");
		}


		[TestMethod]
		public virtual void InnerJoin_Expr()
		{
			var t = DbDef.department;
			var e = DbDef.employee;

			APQuery
				.select(e.EmployeeId, t.DepartmentName, e.Firstname, e.Lastname, e.Birthday, e.State)
				.from(t, e.InnerJoin(t.DepartmentId == e.DepartmentId))
				.print("<table_source> INNER JOIN <table_source> ON <search_condition>");
		}


		[TestMethod]
		public virtual void LeftJoin_Expr()
		{
			var t = DbDef.department;
			var e = DbDef.employee;

			APQuery
				.select(e.EmployeeId, t.DepartmentName, e.Firstname, e.Lastname, e.Birthday, e.State)
				.from(t)
				.leftJoin(e, t.DepartmentId == e.DepartmentId)
				.print("<table_source> LEFT JOIN <table_source> ON <search_condition>");
		}


		[TestMethod]
		public virtual void RightJoin_Expr()
		{
			var t = DbDef.department;
			var e = DbDef.employee;

			APQuery
				.select(e.EmployeeId, t.DepartmentName, e.Firstname, e.Lastname, e.Birthday, e.State)
				.from(t, e.RightJoin(t.DepartmentId == e.DepartmentId))
				.print("<table_source> RIGHT JOIN <table_source> ON <search_condition>");
		}


		[TestMethod]
		public virtual void FullJoin_Expr()
		{
			var t = DbDef.department;
			var e = DbDef.employee;

			APQuery
				.select(e.EmployeeId, t.DepartmentName, e.Firstname, e.Lastname, e.Birthday, e.State)
				.from(t, e.FullJoin(t.DepartmentId == e.DepartmentId))
				.print("<table_source> FULL JOIN <table_source> ON <search_condition>");
		}


		[TestMethod]
		public virtual void CrossJoin_Expr()
		{
			var t = DbDef.department;
			var e = DbDef.employee;

			APQuery
				.select(e.EmployeeId, t.DepartmentName, e.Firstname, e.Lastname, e.Birthday, e.State)
				.from(t, e.CrossJoin())
				.print("<table_source> CROSS JOIN <table_source>");
		}


		[TestMethod]
		public virtual void Self_Join()
		{
			var t = DbDef.department;
			var t1 = t.As<DepartmentTableDef>("dp");

			APQuery
				.select(t.DepartmentId, t.DepartmentName, t1.DepartmentName)
				.from(t, t1.InnerJoin(t.ParentId == t1.DepartmentId))
				.print("<table_source> INNER JOIN <table_source> ON <search_condition>");
		}

	}
}
