using Symber.Data.SqlGen;
using Symber.Data.Utilities;

namespace Symber.Data.SqlSyntex
{

	public class SqlComparisonSubQueryExpr : SqlPredicateExpr
	{

		#region [ Constructors ]


		public SqlComparisonSubQueryExpr(SqlOperableExpr operand, SqlScalarSubQueryExpr subQuery, SqlComparisonOperator @operator)
		{
			Check.NotNull(operand, nameof(operand));
			Check.NotNull(subQuery, nameof(subQuery));

			Operand = operand;
			SubQuery = subQuery;
			Operator = @operator;
		}


		#endregion


		#region [ Properties ]


		public SqlOperableExpr Operand { get; }


		public SqlScalarSubQueryExpr SubQuery { get; }


		public SqlComparisonOperator Operator { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitComparisonSubQuery(this);


		#endregion

	}

}
