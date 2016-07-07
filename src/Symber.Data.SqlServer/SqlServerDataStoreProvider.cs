using Symber.Data.Storage;
using Symber.Data.Utilities;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace Symber.Data.SqlServer
{

	public class SqlServerDataStoreProvider : DataStoreProvider
	{

		#region [ Singleton Instance ]


		private static readonly SqlServerDataStoreProvider _providerInstance = new SqlServerDataStoreProvider();


		public static SqlServerDataStoreProvider Instance
			=> _providerInstance;


		#endregion


		#region [ Override Implementation of DataStoreProvider ]


		public override ConnectionFactory GetConnectionFactory(string connectionString, string providerName)
		{
			Check.NotEmpty(connectionString, nameof(connectionString));


			if (!String.IsNullOrEmpty(providerName))
			{
				try
				{
					DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
					return new SqlServerConnectionFactory(factory, connectionString);
				}
				catch
				{
					throw new DataStoreException(Strings.Providers_NoProviderFound(providerName));
				}
			}

			return new SqlServerConnectionFactory(SqlClientFactory.Instance, connectionString);
		}


		public override SqlGenerator GetGenerator()
		{
			return new SqlServerSqlGenerator();
		}


		#endregion

	}

}
