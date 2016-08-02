using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlFullOuterJoinExpr : SqlJoinExprBase
	{

		#region [ Constructors ]


		public SqlFullOuterJoinExpr(SqlQuerySourceExpr tableExpr)
			: base(tableExpr)
		{
		}


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitFullOuterJoin(this);


		#endregion

	}

}
