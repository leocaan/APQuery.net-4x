using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlSumExpr : SqlDistinctableFunctionExpr
	{

		#region [ Constructors ]


		public SqlSumExpr(SqlOperableExpr operand)
			: base("SUM")
		{
			Check.NotNull(operand, nameof(operand));

			AddParameter(operand);
		}


		#endregion

	}

}
