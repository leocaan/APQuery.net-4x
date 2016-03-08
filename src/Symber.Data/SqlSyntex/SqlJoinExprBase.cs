using Symber.Data.Utilities;

namespace Symber.Data.SqlSyntex
{

	public abstract class SqlJoinExprBase : SqlQuerySourceExpr
	{

		#region [ Fields ]


		private SqlPredicateExpr _predicate;


		#endregion


		#region [ Constructors ]


		protected SqlJoinExprBase(SqlQuerySourceExpr tableExpr)
			: base(Check.NotNull(tableExpr, nameof(tableExpr)).QuerySource, tableExpr.Alias)
		{
			TableExpr = tableExpr;
		}


		#endregion


		#region [ Properties ]


		public SqlQuerySourceExpr TableExpr { get; }


		public SqlPredicateExpr Predicate
		{
			get { return _predicate; }
			set { Check.NotNull(value, nameof(value)); _predicate = value; }
		}


		#endregion

	}

}
