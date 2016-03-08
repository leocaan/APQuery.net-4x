using Symber.Data.SqlGen;
using Symber.Data.Utilities;
using System.Collections.Generic;

namespace Symber.Data.SqlSyntex
{

	public class SqlSelectExpr : SqlQuerySourceExpr
	{

		#region [ Fields ]


		private readonly List<SqlProjectableExpr> _selectClause = new List<SqlProjectableExpr>();
		private readonly List<SqlQuerySourceExpr> _fromClause = new List<SqlQuerySourceExpr>();
		private readonly List<SqlOrderingExpr> _orderByClause = new List<SqlOrderingExpr>();
		private readonly List<SqlGroupableExpr> _groupByClause = new List<SqlGroupableExpr>();
		private readonly List<SqlCombineResultExprBase> _combineResults = new List<SqlCombineResultExprBase>();


		#endregion


		#region [ Constructors ]


		public SqlSelectExpr()
			: this(null)
		{

		}


		public SqlSelectExpr(string alias)
			: base(null, alias)
		{

		}


		#endregion


		#region [ Properties ]


		public virtual bool IsDistinct { get; set; }


		public virtual int? Limit { get; set; }


		public virtual int? Offset { get; set; }


		public virtual SqlColumnExpr PrimaryKeyOptimizing { get; set; }


		#endregion


		#region [ 'SELECT' Clause ]


		public virtual IReadOnlyList<SqlProjectableExpr> SelectClause
			=> _selectClause;


		public virtual SqlSelectExpr AddToSelectClause(SqlProjectableExpr expr)
		{
			_selectClause.Add(expr ?? SqlExpr.NULL);

			return this;
		}


		public virtual SqlSelectExpr AddToSelectClause(IEnumerable<SqlProjectableExpr> exprs)
		{
			Check.NotNull(exprs, nameof(exprs));

			foreach (var expr in exprs)
			{
				_selectClause.Add(expr ?? SqlExpr.NULL);
			}

			return this;
		}


		public virtual SqlSelectExpr AddToSelectClause(params SqlProjectableExpr[] exprs)
		{
			Check.NotNull(exprs, nameof(exprs));

			foreach (var expr in exprs)
			{
				_selectClause.Add(expr ?? SqlExpr.NULL);
			}

			return this;
		}


		public virtual SqlSelectExpr ClearSelectClause()
		{
			_selectClause.Clear();

			return this;
		}


		#endregion


		#region [ 'FROM' Clause ]


		public virtual IReadOnlyList<SqlQuerySourceExpr> FromClause
			=> _fromClause;


		public virtual SqlSelectExpr AddToFromClause(SqlQuerySourceExpr expr)
		{
			_fromClause.Add(Check.NotNull(expr, nameof(expr)));

			return this;
		}


		public virtual SqlSelectExpr AddToFromClause(IEnumerable<SqlQuerySourceExpr> exprs)
		{
			_fromClause.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlSelectExpr AddToFromClause(params SqlQuerySourceExpr[] exprs)
		{
			_fromClause.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlSelectExpr ClearFromClause()
		{
			_fromClause.Clear();

			return this;
		}


		#endregion


		#region [ 'WHERE' Clause ]


		public virtual SqlPredicateExpr WhereClause { get; set; }


		#endregion


		#region [ 'GROUP BY' Clause ]


		public virtual IReadOnlyList<SqlGroupableExpr> GroupByClause
			=> _groupByClause;


		public virtual SqlSelectExpr AddToGroupByClause(SqlGroupableExpr expr)
		{
			_groupByClause.Add(Check.NotNull(expr, nameof(expr)));

			return this;
		}


		public virtual SqlSelectExpr AddToGroupByClause(IEnumerable<SqlGroupableExpr> exprs)
		{
			_groupByClause.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlSelectExpr AddToGroupByClause(params SqlGroupableExpr[] exprs)
		{
			_groupByClause.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlSelectExpr ClearGroupByClause()
		{
			_groupByClause.Clear();

			return this;
		}


		#endregion


		#region [ 'HAVING' Clause ]


		public virtual SqlPredicateExpr HavingClause { get; set; }


		#endregion


		#region [ 'ORDER BY' Clause ]


		public virtual IReadOnlyList<SqlOrderingExpr> OrderByClause
			=> _orderByClause;


		public virtual SqlSelectExpr AddToOrderByClause(SqlOrderingExpr expr)
		{
			_orderByClause.Add(Check.NotNull(expr, nameof(expr)));

			return this;
		}


		public virtual SqlSelectExpr AddToOrderByClause(IEnumerable<SqlOrderingExpr> exprs)
		{
			_orderByClause.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlSelectExpr AddToOrderByClause(params SqlOrderingExpr[] exprs)
		{
			_orderByClause.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlSelectExpr ClearOrderByClause()
		{
			_orderByClause.Clear();

			return this;
		}


		#endregion


		#region [ 'UNION [ALL]', 'INTERSECT' ... Combine Results ]


		public virtual IReadOnlyList<SqlCombineResultExprBase> CombineResults
			=> _combineResults;


		public virtual SqlSelectExpr AddToCombineResults(SqlCombineResultExprBase expr)
		{
			_combineResults.Add(Check.NotNull(expr, nameof(expr)));

			return this;
		}


		public virtual SqlSelectExpr AddToCombineResults(IEnumerable<SqlCombineResultExprBase> exprs)
		{
			_combineResults.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlSelectExpr AddToCombineResults(params SqlCombineResultExprBase[] exprs)
		{
			_combineResults.AddRange(Check.NotNull(exprs, nameof(exprs)));

			return this;
		}


		public virtual SqlSelectExpr ClearCombineResults()
		{
			_combineResults.Clear();

			return this;
		}


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitSelect(this);


		#endregion

	}

}
