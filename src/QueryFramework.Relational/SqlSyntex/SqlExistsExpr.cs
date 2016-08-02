using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlExistsExpr : SqlPredicateExpr
	{

		#region [ Constructors ]


		public SqlExistsExpr(SqlSelectExpr subQueryExpr)
		{
			Check.NotNull(subQueryExpr, nameof(subQueryExpr));

			SubQuery = subQueryExpr;
		}


		#endregion


		#region [ Properties ]


		public SqlSelectExpr SubQuery { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitExists(this);


		#endregion

	}

}
