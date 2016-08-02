using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlAllExpr : SqlScalarSubQueryExpr
	{

		#region [ Consturctors ]


		public SqlAllExpr(SqlSelectExpr subQuery)
			: base(subQuery)
		{
		}


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitAll(this);


		#endregion

	}

}
