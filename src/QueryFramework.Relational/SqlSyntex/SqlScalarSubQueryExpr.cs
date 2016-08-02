using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlScalarSubQueryExpr : SqlExpr
	{

		#region [ Constructors ]


		public SqlScalarSubQueryExpr(SqlSelectExpr subQuery)
		{
			Check.NotNull(subQuery, nameof(subQuery));

			SubQuery = subQuery;
		}


		#endregion


		#region [ Properties ]


		public SqlSelectExpr SubQuery { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitScalarSubQuery(this);


		#endregion


		#region [ Override Implementation of Implicit Operator ]


		public static implicit operator SqlScalarSubQueryExpr(SqlSelectExpr value)
			=> SqlExpr.Scalar(value);


		#endregion

	}
}

