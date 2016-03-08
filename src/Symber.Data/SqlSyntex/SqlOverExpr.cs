using Symber.Data.SqlGen;
using Symber.Data.Utilities;
using System.Collections.Generic;

namespace Symber.Data.SqlSyntex
{

	public class SqlOverExpr : SqlOperableExpr
	{

		#region [ Fields ]


		private readonly List<SqlOperableExpr> _partitionByClause = new List<SqlOperableExpr>();
		private readonly List<SqlOrderingExpr> _orderByClause = new List<SqlOrderingExpr>();


		#endregion


		#region [ Constructors ]


		public SqlOverExpr(SqlFunctionExprBase function)
		{
			Check.NotNull(function, nameof(function));

			Function = function;
		}


		#endregion


		#region [ Properties ]


		public virtual SqlFunctionExprBase Function { get; }


		#endregion


		#region [ 'PARTITION BY' Clause ]


		public virtual IReadOnlyList<SqlOperableExpr> PartitionByClause
			=> _partitionByClause;


		public virtual SqlOverExpr AddToPartitionByClause(SqlOperableExpr expr)
		{
			_partitionByClause.Add(Check.NotNull(expr, nameof(expr)));

			return this;
		}


		public virtual SqlOverExpr AddToPartitionByClause(IEnumerable<SqlOperableExpr> exprs)
		{
			_partitionByClause.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlOverExpr AddToPartitionByClause(params SqlOperableExpr[] exprs)
		{
			_partitionByClause.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlOverExpr ClearPartitionByClause()
		{
			_partitionByClause.Clear();

			return this;
		}


		#endregion


		#region [ 'ORDER BY' Clause ]


		public virtual IReadOnlyList<SqlOrderingExpr> OrderByClause
			=> _orderByClause;


		public virtual SqlOverExpr AddToOrderByClause(SqlOrderingExpr expr)
		{
			_orderByClause.Add(Check.NotNull(expr, nameof(expr)));

			return this;
		}


		public virtual SqlOverExpr AddToOrderByClause(IEnumerable<SqlOrderingExpr> exprs)
		{
			_orderByClause.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlOverExpr AddToOrderByClause(params SqlOrderingExpr[] exprs)
		{
			_orderByClause.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlOverExpr ClearOrderByClause()
		{
			_orderByClause.Clear();

			return this;
		}


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitOver(this);


		#endregion

	}

}
