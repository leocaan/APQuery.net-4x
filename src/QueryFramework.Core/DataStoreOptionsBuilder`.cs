namespace QueryFramework
{

	public class DataStoreOptionsBuilder<TContext> : DataStoreOptionsBuilder
		where TContext : DbContext
	{

		#region [ Constructors ]


		public DataStoreOptionsBuilder()
			: this(new DataStoreOptions<TContext>())
		{
		}

		public DataStoreOptionsBuilder(DataStoreOptions<TContext> options)
				: base(options)
		{
		}


		#endregion


		#region [ Properties ]


		public new virtual DataStoreOptions<TContext> Options
			=> (DataStoreOptions<TContext>)base.Options;


		#endregion

	}

}
