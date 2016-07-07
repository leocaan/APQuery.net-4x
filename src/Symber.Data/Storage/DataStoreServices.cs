using Symber.Data.Utilities;

namespace Symber.Data.Storage
{

	public class DataStoreServices
	{

		#region [ Constructors ]


		public DataStoreServices(DataStoreProvider provider, string connectionString, string providerName)
		{
			Check.NotNull(provider, nameof(provider));
			Check.NotEmpty(providerName, nameof(providerName));

			Provider = provider;
			Generator = provider.GetGenerator();
			ConnectionFactory = provider.GetConnectionFactory(connectionString, providerName);
			ConnectionString = connectionString;
			ProviderName = providerName;
		}


		#endregion


		#region [ Properties ]


		public DataStoreProvider Provider { get; }


		public SqlGenerator Generator { get; }


		public ConnectionFactory ConnectionFactory { get; }


		public string ConnectionString { get; }


		public string ProviderName { get; }


		#endregion

	}

}
