﻿using QueryFramework.Query.Sql;

namespace QueryFramework.Query.SqlSyntex
{

	public static partial class SqlSelectExprExtensions
	{

		public static void print(this SqlSelectExpr query, string description = null)
		{
			var generator = new OracleSqlGenerator(null, null, null, null, null);

			TestHelper.print(generator, query, description);
		}

	}

}
