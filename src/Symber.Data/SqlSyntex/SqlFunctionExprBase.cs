using Symber.Data.SqlGen;
using Symber.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symber.Data.SqlSyntex
{

	public abstract class SqlFunctionExprBase : SqlOperableExpr
	{

		#region [ Fields ]


		private readonly List<SqlOperableExpr> _parameters = new List<SqlOperableExpr>();


		#endregion


		#region [ Constructors ]


		protected SqlFunctionExprBase(string name)
		{
			Check.NotNull(name, nameof(name));

			Name = name;
		}


		#endregion


		#region [ Properties ]


		public virtual string Name { get; }


		#endregion


		#region [ Parameter ]


		public virtual IReadOnlyList<SqlOperableExpr> Parameters
			=> _parameters;


		public virtual SqlFunctionExprBase AddParameter(SqlOperableExpr expr)
		{
			_parameters.Add(Check.NotNull(expr, nameof(expr)));

			return this;
		}


		public virtual SqlFunctionExprBase AddParameter(IEnumerable<SqlOperableExpr> exprs)
		{
			_parameters.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlFunctionExprBase AddParameter(params SqlOperableExpr[] exprs)
		{
			_parameters.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlFunctionExprBase ClearParameters()
		{
			_parameters.Clear();

			return this;
		}


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitSqlFunction(this);


		#endregion

	}

}
