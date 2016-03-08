namespace Symber.Data.SqlSyntex
{

	public abstract class SqlPredicateExpr : SqlExpr
	{

		#region [ Override Implementation of Operator ]


		public static SqlAndExpr operator &(SqlPredicateExpr left, SqlPredicateExpr right)
			=> SqlExpr.AndAlso(left, right);


		public static SqlOrExpr operator |(SqlPredicateExpr left, SqlPredicateExpr right)
			=> SqlExpr.OrElse(left, right);


		public static SqlNotExpr operator !(SqlPredicateExpr expr)
			=> SqlExpr.Not(expr);


		#endregion

	}

}
