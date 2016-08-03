using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlDistinctableFunctionExpr : SqlFunctionExprBase
	{

		#region [ Constructors ]


		public SqlDistinctableFunctionExpr(string name)
			: base(name)
		{
		}


		#endregion


		#region [ Properties ]


		public virtual bool IsDistinct { get; private set; }


		#endregion


		#region [ Methods ]


		public virtual SqlDistinctableFunctionExpr Distinct()
		{
			IsDistinct = true;

			return this;
		}


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlGenerator visitor)
			=> visitor.VisitSqlDistinctableFunction(this);


		#endregion

	}

}
