using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
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


		public override SqlExpr Accept(ISqlGenerator visitor)
			=> visitor.VisitLeftOuterJoin(this);


		#endregion

	}

}
