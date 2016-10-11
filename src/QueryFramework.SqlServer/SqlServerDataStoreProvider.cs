using QueryFramework.Relational;
using QueryFramework.Relational.Storage;

namespace QueryFramework.SqlServer
{

	public class SqlServerDataStoreProvider : DataStoreProvider
	{

		#region [ Singleton Instance ]


		private static readonly SqlServerDataStoreProvider _providerInstance = new SqlServerDataStoreProvider();


		public static SqlServerDataStoreProvider Instance
			=> _providerInstance;


		#endregion


		#region [ Override Implementation of DataStoreProvider ]


		public override RelationalDataStoreServices CreateServices(string connectionString, string providerName)
		{
			var builder = new DataStoreOptionsBuilder();

			builder.UseSqlServer(connectionString);

			return new SqlServerDataStoreServices(builder.Options);
		}


		#endregion

	}

}
