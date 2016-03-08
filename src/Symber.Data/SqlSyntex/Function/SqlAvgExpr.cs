using Symber.Data.SqlGen;
using Symber.Data.Utilities;

namespace Symber.Data.SqlSyntex
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
