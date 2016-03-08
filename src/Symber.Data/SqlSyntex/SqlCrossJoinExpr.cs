using Symber.Data.SqlGen;
using Symber.Data.Utilities;

namespace Symber.Data.SqlSyntex
{

	public class SqlCrossJoinExpr : SqlQuerySourceExpr
	{

		#region [ Constructors ]


		public SqlCrossJoinExpr(SqlQuerySourceExpr tableExpr)
			: base(Check.NotNull(tableExpr, nameof(tableExpr)).QuerySource, tableExpr.Alias)
		{
			TableExpr = tableExpr;
		}


		#endregion


		#region [ Properties ]


		public SqlQuerySourceExpr TableExpr { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitCrossJoin(this);


		#endregion

	}

}
