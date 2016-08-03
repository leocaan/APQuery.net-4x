using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
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


		public override SqlExpr Accept(ISqlGenerator visitor)
			=> visitor.VisitComparison(this);


		#endregion

	}

}
