using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
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
