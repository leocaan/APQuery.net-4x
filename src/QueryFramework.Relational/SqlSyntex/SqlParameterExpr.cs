using QueryFramework.Relational.SqlGen;
using QueryFramework.Utilities;

namespace QueryFramework.Relational.SqlSyntex
{

	public class SqlParameterExpr : SqlOperableExpr
	{

		#region [ Constructors ]


		public SqlParameterExpr(object value)
			:this(value, null)
		{
		}


		public SqlParameterExpr(object value, string name)
		{
			Check.NotNull(value, nameof(value));

			Value = value;
			Name = name;
		}


		#endregion


		#region [ Properties ]


		public virtual object Value { get; }


		public virtual string Name { get; set; }


		#endregion


		#region [ Override Implementation of SqlExpr ]


		public override SqlExpr Accept(ISqlGenerator visitor)
			=> visitor.VisitParameter(this);


		#endregion

	}

}
