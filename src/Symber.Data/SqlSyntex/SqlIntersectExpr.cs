using Symber.Data.SqlGen;

namespace Symber.Data.SqlSyntex
{

	public class SqlIntersectExpr : SqlCombineResultExprBase
	{

		#region [ Constructors ]


		public SqlIntersectExpr(SqlSelectExpr nextQuery)
			:base(nextQuery, "INTERSECT")
		{
		}


		#endregion

	}

}
