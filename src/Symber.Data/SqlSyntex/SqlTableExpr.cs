using Symber.Data.SqlGen;

namespace Symber.Data.SqlSyntex
{

	public class SqlTableExpr : SqlQuerySourceExpr
	{
		
		#region [ Constructors ]


		public SqlTableExpr(ISqlQuerySource querySource, string schema, string name, string alias)
			: base(querySource, alias)
		{
			Schema = schema;
			Name = name;
		}


		#endregion


		#region [ Properties ]


		public virtual string Schema { get; internal set; }


		public virtual string Name { get; internal set; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlExprVisitor visitor)
			=> visitor.VisitTable(this);


		#endregion

	}

}
