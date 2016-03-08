using Symber.Data.SqlGen;

namespace Symber.Data.SqlSyntex
{

	public class SqlExceptExpr : SqlCombineResultExprBase
	{

		#region [ Constructors ]


		public SqlExceptExpr(SqlSelectExpr nextQuery)
			:base(nextQuery, "EXCEPT")
		{
		}


		#endregion

	}

}
