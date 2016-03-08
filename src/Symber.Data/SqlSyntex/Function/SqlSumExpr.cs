﻿using Symber.Data.SqlGen;
using Symber.Data.Utilities;

namespace Symber.Data.SqlSyntex
{

	public class SqlSumExpr : SqlDistinctableFunctionExpr
	{

		#region [ Constructors ]


		public SqlSumExpr(SqlOperableExpr operand)
			: base("SUM")
		{
			Check.NotNull(operand, nameof(operand));

			AddParameter(operand);
		}


		#endregion

	}

}
