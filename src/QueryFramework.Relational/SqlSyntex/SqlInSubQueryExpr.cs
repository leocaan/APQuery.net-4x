using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlInSubQueryExpr : SqlPredicateExpr
	{

		#region [ Constructors ]


		public SqlInSubQueryExpr(SqlOperableExpr operand, SqlSelectExpr subQuery)
		{
			Check.NotNull(operand, nameof(operand));
			Check.NotNull(subQuery, nameof(subQuery));

			Operand = operand;
			SubQuery = subQuery;
		}


		#endregion


		#region [ Properties ]


		public SqlOperableExpr Operand { get; }


		public SqlSelectExpr SubQuery { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitInSubQuery(this);


		#endregion

	}

}
