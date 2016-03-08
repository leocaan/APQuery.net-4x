using Symber.Data.SqlGen;

namespace Symber.Data.SqlSyntex
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
