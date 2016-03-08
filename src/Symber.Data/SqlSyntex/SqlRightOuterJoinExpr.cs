using Symber.Data.SqlGen;

namespace Symber.Data.SqlSyntex
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
