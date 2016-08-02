using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
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
