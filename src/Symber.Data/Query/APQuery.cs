using Symber.Data.SqlSyntex;
using System.Collections.Generic;

namespace Symber.Data.Query
{

	public static class APQuery
	{

		#region [ 'SELECT ']


		public static SqlSelectExpr select(SqlProjectableExpr expr)
			=> new SqlSelectExpr().AddToSelectClause(expr);


		public static SqlSelectExpr select(IEnumerable<SqlProjectableExpr> exprs)
			=> new SqlSelectExpr().AddToSelectClause(exprs);


		public static SqlSelectExpr select(params SqlProjectableExpr[] exprs)
			=> new SqlSelectExpr().AddToSelectClause(exprs);


		#endregion

	}

}
