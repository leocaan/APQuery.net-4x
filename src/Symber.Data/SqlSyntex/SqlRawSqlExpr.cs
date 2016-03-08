using Symber.Data.SqlGen;

namespace Symber.Data.SqlSyntex
{

	public class SqlRawSqlExpr : SqlOperableExpr
	{

		#region [ Consturctors ]


		public SqlRawSqlExpr(string sql)
		{
			Sql = sql;
		}


		#endregion


		#region [ Properties ]


		public virtual string Sql { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitRawSql(this);


		#endregion

	}

}
