using Symber.Data.SqlGen;
using Symber.Data.Utilities;

namespace Symber.Data.SqlSyntex
{

	public class SqlComparisonExpr : SqlPredicateExpr
	{

		#region [ Constructors ]


		public SqlComparisonExpr(SqlOperableExpr left, SqlExpr right, SqlComparisonOperator @operator)
		{
			Check.NotNull(left, nameof(left));
			Check.NotNull(right, nameof(right));

			Left = left;
			Right = right;
			Operator = @operator;
		}


		#endregion


		#region [ Properties ]


		public SqlOperableExpr Left { get; }


		public SqlExpr Right { get; }


		public SqlComparisonOperator Operator { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitComparison(this);


		#endregion

	}

}
