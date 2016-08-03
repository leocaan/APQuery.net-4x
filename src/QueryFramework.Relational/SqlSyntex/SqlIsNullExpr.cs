using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
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


		public override SqlExpr Accept(ISqlGenerator visitor)
			=> visitor.VisitIsNull(this);


		#endregion

	}

}
