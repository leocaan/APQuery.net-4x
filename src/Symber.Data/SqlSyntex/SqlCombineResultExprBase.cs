using Symber.Data.SqlGen;
using Symber.Data.Utilities;

namespace Symber.Data.SqlSyntex
{

	public abstract class SqlCombineResultExprBase : SqlExpr
	{

		#region [ Constructors ]


		protected SqlCombineResultExprBase(SqlSelectExpr nextQuery, string @operator)
		{
			Check.NotNull(nextQuery, nameof(nextQuery));
			Check.NotEmpty(@operator, nameof(@operator));

			NextQuery = nextQuery;
			Operator = @operator;
		}


		#endregion


		#region [ Properties ]


		public virtual string Operator { get; }


		public SqlSelectExpr NextQuery { get; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitCombineResult(this);


		#endregion

	}

}
