using Symber.Data.SqlGen;
using Symber.Data.Utilities;

namespace Symber.Data.SqlSyntex
{

	public class SqlCountExpr : SqlDistinctableFunctionExpr
	{

		#region [ Constructors ]


		public SqlCountExpr(SqlOperableExpr operand)
			: base("COUNT")
		{
			Check.NotNull(operand, nameof(operand));

			AddParameter(operand);
		}


		public SqlCountExpr()
			: base("COUNT")
		{
		}


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitCount(this);


		#endregion

	}

}
