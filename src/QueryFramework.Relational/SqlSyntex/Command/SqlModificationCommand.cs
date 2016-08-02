namespace QueryFramework.Relational.SqlSyntex
{

	public abstract class SqlModificationCommand
	{

		#region [ Constructors ]


		internal SqlModificationCommand(SqlTableExpr target)
		{
			Target = target;
		}


		#endregion


		#region [ Properties ]


		public SqlTableExpr Target { get; }


		#endregion

	}

}
