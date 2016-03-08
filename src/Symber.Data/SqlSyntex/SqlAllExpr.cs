using Symber.Data.SqlGen;

namespace Symber.Data.SqlSyntex
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
