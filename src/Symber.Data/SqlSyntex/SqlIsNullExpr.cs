using Symber.Data.SqlGen;
using Symber.Data.Utilities;

namespace Symber.Data.SqlSyntex
{

	public class SqlIsNullExpr : SqlPredicateExpr
	{

		#region [ Consturctors ]


		public SqlIsNullExpr(SqlOperableExpr operand)
		{
			Check.NotNull(operand, nameof(operand));

			Operand = operand;
		}


		#endregion

		
		#region [ Properties ]


		public SqlOperableExpr Operand { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitIsNull(this);


		#endregion

	}

}
