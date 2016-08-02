namespace QueryFramework.Relational.DBStruct
{

	public abstract class IdentifiableColumnDef<TModel> : ColumnDef<TModel>
	{

		#region [ Properties ]


		public ColumnIdentityType IdentityType { get; set; }


		#endregion

	}

}
