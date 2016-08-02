using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
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
