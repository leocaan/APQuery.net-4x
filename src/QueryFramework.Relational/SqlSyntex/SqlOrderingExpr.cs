﻿using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlOrderingExpr : SqlExpr
	{

		#region [ Constructors ]


		public SqlOrderingExpr(SqlExpr expr, SqlOrderingDirection orderingDirection)
		{
			Operand = expr;
			OrderingDirection = orderingDirection;
		}


		#endregion


		#region [ Properties ]


		public SqlExpr Operand { get; }


		public SqlOrderingDirection OrderingDirection { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlGenerator visitor)
			=> visitor.VisitOrdering(this);


		#endregion

	}

}
