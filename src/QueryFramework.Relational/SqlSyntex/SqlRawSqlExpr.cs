using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
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


		public override SqlExpr Accept(ISqlGenerator visitor)
			=> visitor.VisitRawSql(this);


		#endregion

	}

}
