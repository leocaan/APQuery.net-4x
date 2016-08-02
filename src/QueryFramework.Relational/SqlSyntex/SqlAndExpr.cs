using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlAndExpr : SqlPredicateExpr
	{

		#region [ Consturctors ]


		public SqlAndExpr(SqlPredicateExpr left, SqlPredicateExpr right)
		{
			Check.NotNull(left, nameof(left));
			Check.NotNull(right, nameof(right));

			Left = left;
			Right = right;
		}


		#endregion


		#region [ Properties ]


		public SqlPredicateExpr Left { get; }


		public SqlPredicateExpr Right { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitAnd(this);


		#endregion

	}

}
