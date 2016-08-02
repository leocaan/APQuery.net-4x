using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlAvgExpr : SqlDistinctableFunctionExpr
	{

		#region [ Constructors ]


		public SqlAvgExpr(SqlOperableExpr operand)
			: base("AVG")
		{
			Check.NotNull(operand, nameof(operand));

			AddParameter(operand);
		}


		#endregion

	}

}
