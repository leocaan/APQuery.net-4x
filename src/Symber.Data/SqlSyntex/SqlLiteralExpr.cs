using Symber.Data.SqlGen;

namespace Symber.Data.SqlSyntex
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


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitLiteral(this);


		#endregion

	}

}
