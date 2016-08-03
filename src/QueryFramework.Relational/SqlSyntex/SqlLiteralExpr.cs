using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlLiteralExpr : SqlOperableExpr
	{

		#region [ Constructors ]


		public SqlLiteralExpr(string literal)
		{
			Literal = literal;
		}


		#endregion


		#region [ Properties ]


		public new virtual string Literal { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlGenerator visitor)
			=> visitor.VisitLiteral(this);


		#endregion

	}

}
