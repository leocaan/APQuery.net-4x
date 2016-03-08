using Symber.Data.SqlGen;
using Symber.Data.Utilities;

namespace Symber.Data.SqlSyntex
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
