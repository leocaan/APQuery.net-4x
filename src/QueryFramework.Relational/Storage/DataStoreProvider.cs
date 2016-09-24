using QueryFramework.Infrastructure;

namespace QueryFramework.Relational.Storage
{

	public abstract class DataStoreProvider
	{

		#region [ Methods ]


		public abstract RelationalDataStoreServices CreateServices(string connectionString, string providerName);


		#endregion

	}

}
