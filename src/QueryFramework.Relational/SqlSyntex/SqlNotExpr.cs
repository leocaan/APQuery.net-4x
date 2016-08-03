using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlNotExpr : SqlPredicateExpr
	{

		#region [ Consturctors ]


		public SqlNotExpr(SqlPredicateExpr operand)
		{
			Check.NotNull(operand, nameof(operand));

			Operand = operand;
		}


		#endregion

		
		#region [ Properties ]


		public SqlPredicateExpr Operand { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlGenerator visitor)
			=> visitor.VisitNot(this);


		#endregion

	}

}
