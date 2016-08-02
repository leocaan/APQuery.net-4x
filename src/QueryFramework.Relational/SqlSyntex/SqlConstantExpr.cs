using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlConstantExpr : SqlOperableExpr
	{

		#region [ Constructors ]


		public SqlConstantExpr(object value)
		{
			Value = value;
		}


		#endregion


		#region [ Properties ]


		public virtual object Value { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitConstant(this);


		#endregion

	}

}
