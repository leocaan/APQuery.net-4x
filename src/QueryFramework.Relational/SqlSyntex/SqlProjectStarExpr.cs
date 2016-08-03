using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlProjectStarExpr : SqlProjectableExpr
	{

		#region [ Constructors ]


		public SqlProjectStarExpr(SqlQuerySourceExpr tableExpr)
			: base(null)
		{
			Table = tableExpr;
		}


		#endregion


		#region [ Properties ]


		public virtual SqlQuerySourceExpr Table { get; }


		public override string ResultName
			=> null;


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlGenerator visitor)
			=> visitor.VisitStar(this);


		#endregion

	}

}
