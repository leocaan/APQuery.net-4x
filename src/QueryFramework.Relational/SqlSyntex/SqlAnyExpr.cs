using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlAnyExpr : SqlScalarSubQueryExpr
	{

		#region [ Consturctors ]


		public SqlAnyExpr(SqlSelectExpr subQuery)
			: base(subQuery)
		{
		}


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitAny(this);


		#endregion

	}

}
