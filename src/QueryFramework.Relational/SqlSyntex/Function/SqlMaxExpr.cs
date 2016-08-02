using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlMaxExpr : SqlDistinctableFunctionExpr
	{

		#region [ Constructors ]


		public SqlMaxExpr(SqlOperableExpr operand)
			: base("MAX")
		{
			Check.NotNull(operand, nameof(operand));

			AddParameter(operand);
		}


		#endregion

	}

}
