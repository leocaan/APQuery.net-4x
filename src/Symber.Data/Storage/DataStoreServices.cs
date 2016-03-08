using Symber.Data.Utilities;

namespace Symber.Data.Storage
{

	public class DataStoreServices
	{

		#region [ Fields ]


		private DataStoreProvider _provider;
		private SqlGenerator _queryParser;
		private ConnectionFactory _connectionFactory;
		private string _connectionString;
		private string _providerName;


		#endregion


		#region [ Constructors ]


		public DataStoreServices(DataStoreProvider provider, string connectionString, string providerName)
		{
			Check.NotNull(provider, nameof(provider));
			Check.NotEmpty(providerName, nameof(providerName));

			_provider = provider;
			_queryParser = provider.GetQueryParser();
			_connectionFactory = provider.GetConnectionFactory(providerName, connectionString);
			_connectionString = connectionString;
			_providerName = providerName;
		}


		#endregion


		#region [ Properties ]


		public DataStoreProvider Provider
			=> _provider;


		public SqlGenerator QueryParser
			=> _queryParser;


		public ConnectionFactory ConnectionFactory
			=> _connectionFactory;


		public string ConnectionString
			=> _connectionString;


		public string ProviderName
			=> _providerName;


		#endregion

	}

}
