using Symber.Data.SqlGen;
using Symber.Data.Utilities;

namespace Symber.Data.SqlSyntex
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
