using Symber.Data.SqlGen;
using Symber.Data.Utilities;

namespace Symber.Data.SqlSyntex
{

	public class SqlMinExpr : SqlDistinctableFunctionExpr
	{

		#region [ Constructors ]


		public SqlMinExpr(SqlOperableExpr operand)
			: base("MIN")
		{
			Check.NotNull(operand, nameof(operand));

			AddParameter(operand);
		}


		#endregion

	}

}
