using Symber.Data.SqlGen;
using Symber.Data.Utilities;

namespace Symber.Data.SqlSyntex
{

	public class SqlColumnExpr : SqlOperableExpr
	{

		#region [ Constructors ]


		internal SqlColumnExpr()
		{

		}


		public SqlColumnExpr(SqlQuerySourceExpr tableExpr, string name)
		{
			Check.NotNull(tableExpr, nameof(tableExpr));
			Check.NotEmpty(name, nameof(name));

			Table = tableExpr;
			Name = name;
		}


		#endregion


		#region [ Properties ]


		public virtual SqlQuerySourceExpr Table { get; internal set; }


		public virtual string Name { get; internal set; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitColumn(this);


		#endregion

	}

}
