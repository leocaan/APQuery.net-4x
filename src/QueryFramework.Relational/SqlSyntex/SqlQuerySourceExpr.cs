namespace QueryFramework.Relational.SqlSyntex
{

	public abstract class SqlQuerySourceExpr : SqlExpr
	{

		#region [ Constructors ]


		protected SqlQuerySourceExpr(ISqlQuerySource querySource, string alias)
		{
			QuerySource = querySource;
			Alias = alias;
		}


		#endregion


		#region [ Properties ]


		public ISqlQuerySource QuerySource { get; internal set; }


		public string Alias { get; internal set; }


		#endregion

	}

}
