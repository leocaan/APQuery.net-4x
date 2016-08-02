using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlGroupableExpr : SqlExpr
	{

		#region [ Constructors ]


		public SqlGroupableExpr(SqlOperableExpr operand)
		{
			Operand = operand;
		}


		#endregion


		#region [ Properties ]


		public virtual SqlOperableExpr Operand { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
		{
			Operand.Accept(visitor);
			return this;
		}


		#endregion


		#region [ Override Implementation of Implicit Operator ]


		public static implicit operator SqlGroupableExpr(SqlOperableExpr expr)
			=> new SqlGroupableExpr(expr);


		#endregion

	}

}
