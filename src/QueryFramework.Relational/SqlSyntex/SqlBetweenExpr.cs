using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlBetweenExpr : SqlPredicateExpr
	{

		#region [ Constructors ]


		public SqlBetweenExpr(SqlOperableExpr operand, SqlOperableExpr begin, SqlOperableExpr end)
		{
			Check.NotNull(operand, nameof(operand));
			Check.NotNull(begin, nameof(begin));
			Check.NotNull(end, nameof(end));

			Operand = operand;
			Begin = begin;
			End = end;
		}


		#endregion


		#region [ Properties ]


		public SqlOperableExpr Operand { get; }


		public SqlOperableExpr Begin { get; }


		public SqlOperableExpr End { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlGenerator visitor)
			=> visitor.VisitBetween(this);


		#endregion

	}

}
