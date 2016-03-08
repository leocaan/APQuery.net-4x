using Symber.Data.SqlGen;
using Symber.Data.SqlSyntex;
using System.Linq;

namespace Symber.Data.SqlServer2012.Query
{

	public class SqlServerSqlGenerator : DefaultSqlGenerator
	{

		#region [ Override Implementation of DefaultSqlGenerator ]


		protected override string DelimitIdentifier(string identifier)
			=> "[" + identifier.Replace("]", "]]") + "]";


		protected override void GenerateLimitOffset(SqlSelectExpr selectExpr)
		{
			if (selectExpr.Offset != null && !selectExpr.OrderByClause.Any())
			{
				Sql.AppendLine()
					.Append("ORDER BY @@ROWCOUNT");
			}

			base.GenerateLimitOffset(selectExpr);
		}


		#endregion

	}

}
