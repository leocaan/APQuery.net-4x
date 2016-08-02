using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlRowNumberExpr : SqlFunctionExprBase
	{

		#region [ Constructors ]


		public SqlRowNumberExpr()
			: base("ROW_NUMBER")
		{
		}


		#endregion

	}

}
