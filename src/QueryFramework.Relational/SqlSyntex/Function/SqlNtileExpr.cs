using QueryFramework.Relational.SqlGen;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlNtileExpr : SqlFunctionExprBase
	{

		#region [ Constructors ]


		public SqlNtileExpr(int number)
			: base("NTILE")
		{
			AddParameter(number);
		}


		#endregion

	}

}
