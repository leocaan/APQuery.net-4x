using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlRightOuterJoinExpr : SqlJoinExprBase
	{

		#region [ Constructors ]


		public SqlRightOuterJoinExpr(SqlQuerySourceExpr tableExpr)
			: base(tableExpr)
		{
		}


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitRightOuterJoin(this);


		#endregion

	}

}
