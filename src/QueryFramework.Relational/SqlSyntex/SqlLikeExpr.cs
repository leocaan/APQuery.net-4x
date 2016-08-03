﻿using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlLikeExpr : SqlPredicateExpr
	{

		#region [ Constructors ]


		public SqlLikeExpr(SqlOperableExpr match, SqlOperableExpr pattern)
		{
			Check.NotNull(match, nameof(match));
			Check.NotNull(pattern, nameof(pattern));

			Match = match;
			Pattern = pattern;
		}


		#endregion


		#region [ Properties ]


		public SqlOperableExpr Match { get; }


		public SqlOperableExpr Pattern { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlGenerator visitor)
			=> visitor.VisitLike(this);


		#endregion

	}

}
