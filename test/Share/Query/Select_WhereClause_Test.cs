using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symber.Data.Query;
using Symber.Data.SqlSyntex;
using System.Collections.Generic;

namespace Symber.Data.Tests.Query
{
	[TestClass]
	public class Select_WhereClause_Test
	{

		[TestMethod]
		public virtual void Comparison_Expr()
		{
			var t = DbDef.department;

			// =

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentId == 0)
				.print("WHERE table_source.column_name = @param");

			// <>

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentId != 0)
				.print("WHERE table_source.column_name <> @param");

			// >

			APQuery
				.select(t.ParentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentId > 1)
				.print("WHERE table_source.column_name > @param");

			// <

			APQuery
				.select(t.ParentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentId < 1)
				.print("WHERE table_source.column_name < @param");

			// >=

			APQuery
				.select(t.ParentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentId >= 1)
				.print("WHERE table_source.column_name >= @param");

			// <=

			APQuery
				.select(t.ParentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentId <= 1)
				.print("WHERE table_source.column_name <= @param");
		}

		[TestMethod]
		public virtual void IsNull_Expr()
		{
			var t = DbDef.department;

			// IS NULL

			APQuery
				.select(t.ParentId, t.DepartmentName)
				.from(t)
				.where(t.ParentId == null)
				.print("WHERE table_source.column_name IS NULL");

			// IS NOT NULL

			APQuery
				.select(t.ParentId, t.DepartmentName)
				.from(t)
				.where(t.ParentId != null)
				.print("WHERE table_source.column_name IS NOT NULL");

		}

		[TestMethod]
		public virtual void InExpr_ConstantExpr()
		{
			var t = DbDef.department;

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentId.In(2, 3, 4))
				.print("WHERE table_source.column_name IN (2, 3, 4)");

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentId.In(
					SqlExpr.Parameter(new int[] { 2, 3, 4 })
					))
				.print("WHERE table_source.column_name IN (2, 3, 4)");

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentId.NotIn(new List<int> { 2, 3, 4 }))
				.print("WHERE table_source.column_name NOT IN (2, 3, 4)");
		}

		[TestMethod]
		public virtual void InExpr_ParameterExpr()
		{
			var t = DbDef.department;

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentId.In(
					SqlExpr.Parameter(3),
					SqlExpr.Parameter(4),
					SqlExpr.Parameter(5)
					))
				.print("WHERE table_source.column_name IN (@param, [...])");

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentId.NotIn(
					new SqlParameterExpr[]
					{
					SqlExpr.Parameter(3),
					SqlExpr.Parameter(4),
					SqlExpr.Parameter(5)
					}
					))
				.print("WHERE table_source.column_name NOT IN (@param, [...])");
		}

		[TestMethod]
		public virtual void Between_Expr()
		{
			var t = DbDef.department;

			// BETWEEN begin AND end

			APQuery
				.select(t.ParentId, t.DepartmentName)
				.from(t)
				.where(t.ParentId.Between(1, 2))
				.print("WHERE table_source.column_name BETWEEN 1 AND 2");

			// NOT BETWEEN begin AND end

			APQuery
				.select(t.ParentId, t.DepartmentName)
				.from(t)
				.where(t.ParentId.NotBetween(1, 2))
				.print("WHERE table_source.column_name NOT BETWEEN 1 AND 2");

		}

		[TestMethod]
		public virtual void Like_Expr()
		{
			var t = DbDef.department;

			// LIKE

			APQuery
				.select(t.ParentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentName.Like("%abc%"))
				.print("WHERE table_source.column_name LIKE '%abc%'");

			// NOT LIKE

			APQuery
				.select(t.ParentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentName.NotLike("%abc%"))
				.print("WHERE table_source.column_name NOT LIKE '%abc%'");

			// StartWith

			APQuery
				.select(t.ParentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentName.StartWith("abc"))
				.print("WHERE table_source.column_name LIKE 'abc%'");

			// EndWith

			APQuery
				.select(t.ParentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentName.EndWith("abc"))
				.print("WHERE table_source.column_name LIKE '%abc'");

			// Contains

			APQuery
				.select(t.ParentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentName.Contains("abc"))
				.print("WHERE table_source.column_name LIKE '%abc%'");

		}

		[TestMethod]
		public virtual void AND_OR_NOT()
		{
			var t = DbDef.department;

			// NOT

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(!(t.DepartmentId == 0))
				.print("NOT(a)");

			// AND

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentId == 0 & t.ParentId != 0)
				.print("a AND b");

			// OR

			var qry = APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where(t.DepartmentId == 0 | t.ParentId != 0);
			qry.WhereClause |= (t.ParentId == 1);
			qry.print("a OR b");

			// AND OR NOT

			APQuery
				.select(t.DepartmentId, t.DepartmentName)
				.from(t)
				.where((t.DepartmentId == 0 & t.ParentId != 0) | (t.DepartmentId == 0 & !(t.ParentId != 0)))
				.print("(a AND b) OR (c AND NOT(d) )");
		}

	}
}
