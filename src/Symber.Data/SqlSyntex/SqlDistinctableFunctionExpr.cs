using Symber.Data.SqlGen;
using Symber.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symber.Data.SqlSyntex
{

	public class SqlDistinctableFunctionExpr : SqlFunctionExprBase
	{

		#region [ Constructors ]


		public SqlDistinctableFunctionExpr(string name)
			: base(name)
		{
		}


		#endregion


		#region [ Properties ]


		public virtual bool IsDistinct { get; private set; }


		#endregion


		#region [ Methods ]


		public virtual SqlDistinctableFunctionExpr Distinct()
		{
			IsDistinct = true;

			return this;
		}


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitSqlDistinctableFunction(this);


		#endregion

	}

}
