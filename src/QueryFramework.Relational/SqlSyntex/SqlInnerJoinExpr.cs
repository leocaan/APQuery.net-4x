﻿using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlInnerJoinExpr : SqlJoinExprBase
	{

		#region [ Constructors ]


		public SqlInnerJoinExpr(SqlQuerySourceExpr tableExpr)
			: base(tableExpr)
		{
		}


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitInnerJoin(this);


		#endregion

	}

}