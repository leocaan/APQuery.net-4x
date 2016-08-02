using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlAliasExpr : SqlProjectableExpr
	{

		#region [ Constructors ]


		public SqlAliasExpr(SqlOperableExpr operand, string alias)
			: base(Check.NotNull(operand, nameof(operand)))
		{
			Check.NotEmpty(alias, nameof(alias));

			Operand = operand;
			Alias = alias;
		}


		#endregion


		#region [ Properties ]


		public override SqlOperableExpr Operand { get; }


		public virtual string Alias { get; }


		public override string ResultName
			=> Alias;

		#endregion


		#region [ 'Ordering' ]


		public new SqlOrderingExpr Asc
			=> SqlExpr.Asc(this);


		public new SqlOrderingExpr Desc
			=> SqlExpr.Desc(this);


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitAlias(this);


		#endregion

	}

}
