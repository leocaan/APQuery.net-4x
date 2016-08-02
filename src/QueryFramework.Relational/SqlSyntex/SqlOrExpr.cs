using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlOrExpr : SqlPredicateExpr
	{

		#region [ Consturctors ]


		public SqlOrExpr(SqlPredicateExpr left, SqlPredicateExpr right)
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
			=> visitor.VisitOr(this);


		#endregion

	}

}
