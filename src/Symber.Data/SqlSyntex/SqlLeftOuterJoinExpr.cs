using Symber.Data.SqlGen;

namespace Symber.Data.SqlSyntex
{

	public class SqlLeftOuterJoinExpr : SqlJoinExprBase
	{

		#region [ Constructors ]


		public SqlLeftOuterJoinExpr(SqlQuerySourceExpr tableExpr)
			: base(tableExpr)
		{
		}


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitLeftOuterJoin(this);


		#endregion

	}

}
