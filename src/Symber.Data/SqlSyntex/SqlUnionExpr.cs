using Symber.Data.SqlGen;

namespace Symber.Data.SqlSyntex
{

	public class SqlUnionExpr : SqlCombineResultExprBase
	{

		#region [ Constructors ]


		public SqlUnionExpr(SqlSelectExpr nextQuery, bool isAll)
			:base(nextQuery, isAll ? "UNION ALL" : "UNION")
		{
		}


		#endregion


		#region [ Properties ]


		public virtual bool IsAll { get; }


		#endregion

	}

}
