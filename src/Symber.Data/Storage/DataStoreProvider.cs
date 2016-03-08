namespace Symber.Data.Storage
{

	public abstract class DataStoreProvider
	{

		#region [ Constructors ]


		protected DataStoreProvider()
		{

		}


		#endregion


		#region [ Methods ]


		public abstract SqlGenerator GetQueryParser();


		public abstract ConnectionFactory GetConnectionFactory(string connectionString, string providerName);


		#endregion

	}

}
