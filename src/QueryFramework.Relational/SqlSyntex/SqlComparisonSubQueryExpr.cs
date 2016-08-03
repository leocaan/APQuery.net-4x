using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
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


		public override SqlExpr Accept(ISqlGenerator visitor)
			=> visitor.VisitComparisonSubQuery(this);


		#endregion

	}

}
