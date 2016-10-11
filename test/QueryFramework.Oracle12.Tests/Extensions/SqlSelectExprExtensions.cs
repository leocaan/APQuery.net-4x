using QueryFramework.Query.Sql;

namespace QueryFramework.Query.SqlSyntex
{

	public static partial class SqlSelectExprExtensions
	{

		public static void print(this SqlSelectExpr query, string description = null)
		{
			var generator = new Oracle12SqlGenerator(null, null, null, null, null);

			TestHelper.print(generator, query, description);
		}

	}

}
